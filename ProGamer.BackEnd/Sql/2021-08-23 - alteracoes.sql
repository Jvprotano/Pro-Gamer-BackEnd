create table [User] (
	Id int identity(1,1) not null,
	[Name] nvarchar(300) not null,
	LastName nvarchar(300) not null,
	Email nvarchar(400) not null,
	Active bit not null,
	DateBirth date not null,
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_User primary key(Id),
)

create table CourseCategory (
	Id int identity(1,1) not null,
	Active bit not null,
	[Name] nvarchar(100) not null,
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_CourseCategory primary key(Id)
)

create table Game (
	Id int identity(1,1) not null,
	Active bit not null,
	[Name] nvarchar(300) not null,
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_Game primary key(Id)
)

create table Course (
	Id int identity(1,1) not null,
	GameId int not null,
	UserId int not null,
	CourseCategoryId int not null,
	Duration int not null,
	[Value] decimal(10,2) not null,
	[Description] nvarchar(max) not null,
	Active bit not null,
	Title nvarchar(300) not null,
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_Course primary key(Id),
	constraint FK_Course_Game foreign key(GameId) references Game (Id),
	constraint FK_Course_User foreign key(UserId) references [User] (Id),
	constraint FK_Course_CourseCategory foreign key(CourseCategoryId) references CourseCategory (Id)
)

create table CourseRating (
	Id int identity(1,1) not null,
	CourseId int not null,
	UserId int not null,
	Note int not null,
	Comment nvarchar(500) null, 
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_CourseRating primary key(Id),
	constraint FK_CourseRating_Course foreign key(CourseId) references Course (Id),
	constraint FK_CourseRating_User foreign key(UserId) references [User] (Id)
)

create table Chat (
	Id int identity(1,1) not null,
	Active bit not null,
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_Chat primary key(Id),
)

create table ChatMessage (
	Id int identity(1,1) not null,
	ChatId int not null,
	UserId int not null,
	DateSend datetime not null,
	Message nvarchar(max) not null,
	constraint PK_ChatMessage primary key(Id),
	constraint FK_ChatMessage_Chat foreign key(ChatId) references Chat (Id),
	constraint FK_ChatMessage_User foreign key(UserId) references [User] (Id)
)

create table PaymentStatus (
	Id int identity(1,1) not null,
	Title nvarchar(200) not null,
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_PaymentStatus primary key(Id),
)

create table AccountType (
	Id int identity(1,1) not null,
	[Key] nvarchar(50) not null,
	Active bit not null,
	Title nvarchar(200) not null,
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_AccountType primary key(Id),
)

create table Account (
	Id int identity(1,1) not null,
	AccountTypeId int not null,
	UserId int not null,
	Digit nvarchar(10) not null,
	Number nvarchar(50) not null,
	Agency nvarchar(20) not null,
	NameBank nvarchar(300) not null,
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_Account primary key(Id),
	constraint FK_Account_AccountType foreign key(AccountTypeId) references AccountType (Id),
	constraint FK_Account_User foreign key(UserId) references [User] (Id)
)

create table PaymentType (
	Id int identity(1,1) not null,
	[Key] nvarchar(50) not null,
	Active bit not null,
	Title nvarchar(200) not null,
    DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_TypePayment primary key(Id),
)

create table Payment (
	Id int identity(1,1) not null,
	LastFourDigits nvarchar(10),
	CardCpf nvarchar(10),
	CardFlag nvarchar(100),
	[Value] decimal(10,2) not null,
	NumberInstallments int not null,
	PaymentRequest nvarchar(max),
	PaymentReponse nvarchar(max),
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_Payment primary key(Id),
)

create table Purchase (
	Id int identity(1,1) not null,
	PaymentTypeId int not null,
	UserId int not null,
	CourseId int not null,
	PaymentId int not null,
	PaymentStatusId int not null,
	Code nvarchar(100),
	DatePurchase datetime not null,
	constraint PK_Purchase primary key(Id),
	constraint FK_Purchase_PaymentType foreign key(PaymentTypeId) references PaymentType (Id),
	constraint FK_Purchase_User foreign key(UserId) references [User] (Id),
	constraint FK_Purchase_Course foreign key(CourseId) references Course (Id),
	constraint FK_Purchase_Payment foreign key(PaymentId) references Payment (Id),
	constraint FK_Purchase_PaymentStatus foreign key(PaymentStatusId) references PaymentStatus (Id),
)

create table Wallet (
	Id int identity(1,1) not null,
	UserId int not null,
	Balance decimal(10,2) not null,
	DateUtcInsert datetime not null,
	DateUtcUpdate datetime null,
	constraint PK_Wallet primary key(Id),
	constraint FK_Wallet_User foreign key(UserId) references [User] (Id),
)

