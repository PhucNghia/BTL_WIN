use MASTER
go

if exists(select * from sysdatabases where name = 'DB_ATM')
	drop database DB_ATM
create database DB_ATM

use DB_ATM;
go

---------------------------------
create table Config(
	ConfigID varchar(30) primary key,
	DateModified date,
	MinWithDraw decimal,
	MaxWithDraw decimal,
	NumPerPage int
);
---------------------------------
create table Customer(
	CustomerID varchar(30) primary key,
	Name nvarchar(50),
	Phone char(15),
	Email varchar(30),
	Address nvarchar(100)
);
---------------------------------
create table OverDraft(
	ODID varchar(30) primary key,
	Value decimal,
);
---------------------------------
create table WithDrawLimit(
	WDID varchar(30) primary key,
	Value decimal,
);
---------------------------------
create table Account(
	AccountID varchar(30) primary key,
	CustID varchar(30),
	AccountNo varchar(20),
	ODID varchar(30),
	WDID varchar(30),
	Balance decimal,
	constraint FK_Account_Customer foreign key(CustID)
		references Customer(CustomerID) on update cascade on delete cascade,
	constraint FK_Account_OverDraft foreign key(ODID)
		references OverDraft(ODID) on update cascade on delete cascade,
	constraint FK_Account_WithDrawLimit foreign key(WDID)
		references WithDrawLimit(WDID) on update cascade on delete cascade,
);
---------------------------------
create table Card(
	CardNo varchar(30) primary key,
	Status nvarchar(30),
	AccountID varchar(30),
	PIN char(10),
	StartDate date,
	ExpiredDate date,
	Attempt int,
	constraint FK_Card_Account foreign key(AccountID)
		references Account(AccountID) on update cascade on delete cascade
);
---------------------------------
create table Money(
	MoneyID varchar(30) primary key,
	MoneyValue decimal
);
---------------------------------
create table ATM(
	ATMID varchar(30) primary key,
	Branch nvarchar(50),
	Address nvarchar(100)
);
---------------------------------
create table Stock(
	StockID varchar(30) primary key,
	MoneyID varchar(30),
	ATMID varchar(30),
	Quantity int
	constraint FK_Stock_Money foreign key(MoneyID) 
		references Money(MoneyID) on update cascade on delete cascade,
	constraint FK_Stock_ATM foreign key(ATMID) 
		references ATM(ATMID) on update cascade on delete cascade
);
---------------------------------
create table LogType(
	LogTypeID varchar(30) primary key,
	Description nvarchar(100)
);
---------------------------------
create table Log(
	LogID varchar(30) primary key,
	LogTypeID varchar(30),
	ATMID varchar(30),
	CardNo varchar(30),
	LogDate datetime,
	Amount decimal,
	Details nvarchar(100),
	CardNoTo varchar(30),
	constraint FK_Log_LogType foreign key(LogTypeID) 
		references LogType(LogTypeID) on update cascade on delete cascade,
	constraint FK_Log_ATM foreign key(ATMID) 
		references ATM(ATMID) on update cascade on delete cascade,
	constraint FK_Log_Card foreign key(CardNo) 
		references Card(CardNo) on update cascade on delete cascade
);


---------------------------------
insert into Config values('CONFIG001', '2018/11/13', 50000, 17500000, 5);
---------------------------------
insert into Customer values('1041260143', N'Nguyễn Hoàng Nam Anh', '0382681682', 'namanh@gmail.com', N'Vĩnh Phúc');
insert into Customer values('1041260144', N'Hoàng Văn Hậu', '0382681682', 'hoanghau@gmail.com', N'Hải Dương');
insert into Customer values('1041260145', N'Phúc Ngọc Nghĩa', '0382305339', 'ngocnghia@gmail.com', N'Tuyên Quang');
insert into Customer values('1041260146', N'Nguyễn Thị Sim', '0382681682', 'nguyensim@gmail.com', N'Lào Cai');
---------------------------------
insert into OverDraft values('OD001', 200000);
---------------------------------
insert into WithDrawLimit values('WDL001', 200000);
---------------------------------
insert into Account values('ACC001', '1041260143', '1234567891', 'OD001', 'WDL001', 100000);
insert into Account values('ACC002', '1041260144', '1234567892', 'OD001', 'WDL001', 100000);
insert into Account values('ACC003', '1041260145', '1234567893', 'OD001', 'WDL001', 100000);
insert into Account values('ACC004', '1041260146', '1234567894', 'OD001', 'WDL001', 100000);
---------------------------------
insert into Card values('1234567891011', 'normal', 'ACC001', '111111', '2015/11/11', '2019/11/11', 0);
insert into Card values('1234567891012', 'normal', 'ACC002', '222222', '2015/11/12', '2019/11/12', 0);
insert into Card values('1234567891013', 'block', 'ACC003', '333333', '2015/11/13', '2019/11/13', 3);
insert into Card values('1234567891014', 'normal', 'ACC004', '444444', '2015/11/14', '2019/11/14', 0);
--------------------------------
insert into Money values('MONEY001', 10000);
insert into Money values('MONEY002', 20000);
insert into Money values('MONEY003', 50000);
insert into Money values('MONEY004', 100000);
insert into Money values('MONEY005', 200000);
insert into Money values('MONEY006', 500000);
---------------------------------
insert into ATM values('ATM001', N'Bắc Từ Liêm', N'Đại học Công Nghiệp Hà Nội');
insert into ATM values('ATM002', N'Cầu Giấy', N'Đại học Sư Phạm Hà Nội');
insert into ATM values('ATM003', N'Đống Đa', N'Đại học Luật');
---------------------------------
insert into Stock values('STOCK001', 'MONEY001', 'ATM001', 100);
insert into Stock values('STOCK002', 'MONEY002', 'ATM001', 100);
insert into Stock values('STOCK003', 'MONEY003', 'ATM001', 100);
insert into Stock values('STOCK004', 'MONEY004', 'ATM001', 100);
insert into Stock values('STOCK005', 'MONEY005', 'ATM001', 100);
insert into Stock values('STOCK006', 'MONEY006', 'ATM001', 100);

insert into Stock values('STOCK007', 'MONEY001', 'ATM002', 100);
insert into Stock values('STOCK008', 'MONEY002', 'ATM002', 100);
insert into Stock values('STOCK009', 'MONEY003', 'ATM002', 100);
insert into Stock values('STOCK010', 'MONEY004', 'ATM002', 100);
insert into Stock values('STOCK011', 'MONEY005', 'ATM002', 100);
insert into Stock values('STOCK012', 'MONEY006', 'ATM002', 100);

insert into Stock values('STOCK013', 'MONEY001', 'ATM003', 100);
insert into Stock values('STOCK014', 'MONEY002', 'ATM003', 100);
insert into Stock values('STOCK015', 'MONEY003', 'ATM003', 100);
insert into Stock values('STOCK016', 'MONEY004', 'ATM003', 100);
insert into Stock values('STOCK017', 'MONEY005', 'ATM003', 100);
insert into Stock values('STOCK018', 'MONEY006', 'ATM003', 100);
---------------------------------
insert into LogType values('LT001', 'Withdraw');
insert into LogType values('LT002', 'Transfer');
insert into LogType values('LT003', 'Check balance');
insert into LogType values('LT004', 'Change PIN');
---------------------------------
insert into Log values('LOG006', 'LT001', 'ATM001', '1234567891011', Convert(datetime, getdate(), 5), 500000, N'Rút tiền thành công', '');
insert into Log values('LOG002', 'LT002', 'ATM001', '1234567891011', Convert(datetime, getdate(), 5), 1000000, N'Chuyển tiền thành công', '1234567891012');
insert into Log values('LOG003', 'LT003', 'ATM001', '1234567891013', Convert(datetime, getdate(), 5), 1000, N'Vấn tin thành công', '');
insert into Log values('LOG004', 'LT004', 'ATM001', '1234567891011', Convert(datetime, getdate(), 5), null, N'Đổi pin thành công', '');

--------------------------------
select * from Config
---------------------------------
select * from Customer
---------------------------------
select * from OverDraft
---------------------------------
select * from WithDrawLimit
---------------------------------
select * from Account
---------------------------------
select * from Card
---------------------------------
select * from Money
---------------------------------
select * from ATM
---------------------------------
select * from Stock
---------------------------------
select * from LogType
---------------------------------
select * from Log

select Log.amount, Log.logdate from Card inner join Log on Card.CardNo = Log.CardNo
	inner join ATM on ATM.ATMID = Log.ATMID
	inner join LogType on LogType.LogTypeID = Log.LogTypeID
	where Card.CardNo = '1234567891011' And ATM.ATMID = 'ATM001' And LogType.LogTypeID = 'LT001'
	And LogDate >= '2018-12-01 00:00:00' and LogDate <= '2018-12-01 23:59:59'
	select getdate()

	select sum(Log.Amount) from Card inner join Log on Card.CardNo = Log.CardNo 
                    inner join ATM on ATM.ATMID = Log.ATMID
                    inner join LogType on LogType.LogTypeID = Log.LogTypeID
                    where LogType.LogTypeID = 'LT001' And ATM.ATMID = 'ATM001' And Card.CardNo = '1234567891011' And
                    LogDate >= '2018-12-01 00:00:00' and LogDate <= '2018-12-01 23:59:59'
