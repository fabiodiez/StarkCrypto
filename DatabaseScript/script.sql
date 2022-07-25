create table Coins
(
	Id int auto_increment primary key,
	Symbol varchar(10),
	CoinName varchar(10),
	SymbolBitfinex varchar(10),
	Status int default 0
);

create table Pairs
(
	Id int auto_increment primary key,
	ExchangeId varchar(10),
	PairName varchar(10),
	FirstCoin varchar(10),
	SecondCoin varchar(10),
	Status int default 0
);


create table Exchanges
(
	Id int auto_increment primary key,
	Name varchar(10),
	ApiKey varchar(10),
	ApiSecret varchar(10),
	Email varchar(10),
	Tax decimal(6,2),
	Status int default 0
);


create table ExchangeCoins
(
	Id int auto_increment primary key,
	ExchangeId varchar(10),
	CoinId varchar(10),
	Address varchar(10),
	Tag varchar(10),
	Status int default 0
);


create table Opportunities
(
	Id int auto_increment primary key,
	OrderBookId int,
	FirstExchangeId int,
	FirstCoinId int,
	SecondExchangeId int,
	SecondCoinId int,
	FirstSpread decimal(10,4),
	SecondSpread decimal(10,4),
	Profit decimal(10,4),
	CreatedDate DateTime
);

 
create table OrderBookBase
(
	Id int auto_increment primary key,
	ExchangeId int,
	CoinId int,
	Ask decimal(16,8),
	Bid decimal(16,8),
	AskVolume decimal(16,8),
	BidVolume decimal(16,8),
	AvgAsk5Min decimal(16,8),
	AvgAsk10Min decimal(16,8),
	AvgAsk15Min decimal(16,8),
	AvgAsk20Min decimal(16,8),
	AvgAsk30Min decimal(16,8),
	AvgAsk60Min decimal(16,8),	
	AvgBid5Min decimal(16,8),
	AvgBid10Min decimal(16,8),
	AvgBid15Min decimal(16,8),
	AvgBid20Min decimal(16,8),
	AvgBid30Min decimal(16,8),
	AvgBid60Min decimal(16,8),
	CreatedDate DateTime
);

 create table Users
(
	Id int auto_increment primary key,
	Name varchar(60),
	Password varchar(60),
	Email varchar(60),
	CellPhone varchar(60),
	Cpf varchar(60),
	Perfil int,
	isAdmin int default 0,
	Status int default 0
);
