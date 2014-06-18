
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3C89F447DD163D0B]') AND parent_object_id = OBJECT_ID('Advertisements'))
alter table Advertisements  drop constraint FK3C89F447DD163D0B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8848AC76AB87632C]') AND parent_object_id = OBJECT_ID('Answers'))
alter table Answers  drop constraint FK8848AC76AB87632C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1527E798FCE63FA]') AND parent_object_id = OBJECT_ID('Areas'))
alter table Areas  drop constraint FK1527E798FCE63FA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK359404FB9C9B9D65]') AND parent_object_id = OBJECT_ID('Articles'))
alter table Articles  drop constraint FK359404FB9C9B9D65


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKED2B71093A35E5A7]') AND parent_object_id = OBJECT_ID('ArticleClasses'))
alter table ArticleClasses  drop constraint FKED2B71093A35E5A7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK307F8259AB87632C]') AND parent_object_id = OBJECT_ID('BuyOrders'))
alter table BuyOrders  drop constraint FK307F8259AB87632C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK909B6703AB87632C]') AND parent_object_id = OBJECT_ID('Comments'))
alter table Comments  drop constraint FK909B6703AB87632C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD29839755B7DF7F6]') AND parent_object_id = OBJECT_ID('CommonCodes'))
alter table CommonCodes  drop constraint FKD29839755B7DF7F6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF92D7840AB87632C]') AND parent_object_id = OBJECT_ID('Favorites'))
alter table Favorites  drop constraint FKF92D7840AB87632C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD51F85E5AB87632C]') AND parent_object_id = OBJECT_ID('IntegralRecords'))
alter table IntegralRecords  drop constraint FKD51F85E5AB87632C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK130DE5A8F3DFDE29]') AND parent_object_id = OBJECT_ID('InternalMsgs'))
alter table InternalMsgs  drop constraint FK130DE5A8F3DFDE29


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK130DE5A8F7839D66]') AND parent_object_id = OBJECT_ID('InternalMsgs'))
alter table InternalMsgs  drop constraint FK130DE5A8F7839D66


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4A7FD86AF87F9540]') AND parent_object_id = OBJECT_ID('Products'))
alter table Products  drop constraint FK4A7FD86AF87F9540


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4A7FD86A89DC90E1]') AND parent_object_id = OBJECT_ID('Products'))
alter table Products  drop constraint FK4A7FD86A89DC90E1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK45425C328714F9F5]') AND parent_object_id = OBJECT_ID('ProductClasses'))
alter table ProductClasses  drop constraint FK45425C328714F9F5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK23DC49281A743508]') AND parent_object_id = OBJECT_ID('Questions'))
alter table Questions  drop constraint FK23DC49281A743508


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK23DC4928AB87632C]') AND parent_object_id = OBJECT_ID('Questions'))
alter table Questions  drop constraint FK23DC4928AB87632C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK54C3A08C6C69CAA8]') AND parent_object_id = OBJECT_ID('QuestionClasses'))
alter table QuestionClasses  drop constraint FK54C3A08C6C69CAA8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC348B9DCAB87632C]') AND parent_object_id = OBJECT_ID('SignIns'))
alter table SignIns  drop constraint FKC348B9DCAB87632C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C1C7FE5EC3DAEBA]') AND parent_object_id = OBJECT_ID('Users'))
alter table Users  drop constraint FK2C1C7FE5EC3DAEBA


    if exists (select * from dbo.sysobjects where id = object_id(N'Settings') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Settings

    if exists (select * from dbo.sysobjects where id = object_id(N'Activities') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Activities

    if exists (select * from dbo.sysobjects where id = object_id(N'AdsClasses') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AdsClasses

    if exists (select * from dbo.sysobjects where id = object_id(N'Advertisements') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Advertisements

    if exists (select * from dbo.sysobjects where id = object_id(N'Answers') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Answers

    if exists (select * from dbo.sysobjects where id = object_id(N'Areas') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Areas

    if exists (select * from dbo.sysobjects where id = object_id(N'Articles') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Articles

    if exists (select * from dbo.sysobjects where id = object_id(N'ArticleClasses') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ArticleClasses

    if exists (select * from dbo.sysobjects where id = object_id(N'BaLaBaLas') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table BaLaBaLas

    if exists (select * from dbo.sysobjects where id = object_id(N'Brands') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Brands

    if exists (select * from dbo.sysobjects where id = object_id(N'BuyOrders') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table BuyOrders

    if exists (select * from dbo.sysobjects where id = object_id(N'Comments') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Comments

    if exists (select * from dbo.sysobjects where id = object_id(N'CommonCodes') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CommonCodes

    if exists (select * from dbo.sysobjects where id = object_id(N'Favorites') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Favorites

    if exists (select * from dbo.sysobjects where id = object_id(N'IntegralRecords') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table IntegralRecords

    if exists (select * from dbo.sysobjects where id = object_id(N'InternalMsgs') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table InternalMsgs

    if exists (select * from dbo.sysobjects where id = object_id(N'Products') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Products

    if exists (select * from dbo.sysobjects where id = object_id(N'ProductClasses') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ProductClasses

    if exists (select * from dbo.sysobjects where id = object_id(N'Questions') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Questions

    if exists (select * from dbo.sysobjects where id = object_id(N'QuestionClasses') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table QuestionClasses

    if exists (select * from dbo.sysobjects where id = object_id(N'SignIns') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SignIns

    if exists (select * from dbo.sysobjects where id = object_id(N'SysLogs') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SysLogs

    if exists (select * from dbo.sysobjects where id = object_id(N'Tags') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Tags

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    create table Settings (
        Id NVARCHAR(255) not null,
       Value NVARCHAR(1000) null,
       Type NVARCHAR(4000) null,
       primary key (Id)
    )

    create table Activities (
        Id INT IDENTITY NOT NULL,
       Title NVARCHAR(255) null,
       Keyword NVARCHAR(255) null,
       Descrp NVARCHAR(255) null,
       PicUrl NVARCHAR(255) null,
       Content NVARCHAR(MAX) null,
       StartDate NVARCHAR(255) null,
       AddTime DATETIME null,
       SignInStartTime DATETIME null,
       SignInEndTime DATETIME null,
       TotleUser INT null,
       CurrentCount INT null,
       ClickRate INT null,
       Price DECIMAL(19,5) null,
       Tel NVARCHAR(255) null,
       Address NVARCHAR(255) null,
       Recommend INT null,
       primary key (Id)
    )

    create table AdsClasses (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       primary key (Id)
    )

    create table Advertisements (
        Id INT IDENTITY NOT NULL,
       Title NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       PicUrl NVARCHAR(255) null,
       Link NVARCHAR(255) null,
       AddTime DATETIME null,
       ClickCount INT null,
       AdsClassFk INT null,
       primary key (Id)
    )

    create table Answers (
        Id INT IDENTITY NOT NULL,
       QuestionId INT null,
       IpAddress NVARCHAR(255) null,
       NickName NVARCHAR(255) null,
       AddTime DATETIME null,
       Content NVARCHAR(MAX) null,
       IsBest BIT null,
       UserFk INT null,
       primary key (Id)
    )

    create table Areas (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       ParentFk INT null,
       primary key (Id)
    )

    create table Articles (
        Id INT IDENTITY NOT NULL,
       Title NVARCHAR(255) null,
       ArticleFrom INT null,
       Keyword NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       Content NVARCHAR(MAX) null,
       ClickCount INT null,
       UpdateTime DATETIME null,
       PicUrl NVARCHAR(255) null,
       IsTop BIT null,
       IsNice BIT null,
       ArticleClassFk INT null,
       primary key (Id)
    )

    create table ArticleClasses (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       Keyword NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       AddTime DATETIME null,
       ParentFk INT null,
       primary key (Id)
    )

    create table BaLaBaLas (
        Id INT IDENTITY NOT NULL,
       LoginName NVARCHAR(255) null,
       Pwd NVARCHAR(255) null,
       RealName NVARCHAR(255) null,
       AddTime DATETIME null,
       LoginCount INT null,
       primary key (Id)
    )

    create table Brands (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Description NVARCHAR(MAX) null,
       PicUrl NVARCHAR(255) null,
       ProductCount INT null,
       UpdateTime DATETIME null,
       primary key (Id)
    )

    create table BuyOrders (
        Id INT IDENTITY NOT NULL,
       ProductCount INT null,
       TotleMoney DECIMAL(19,5) null,
       Address NVARCHAR(255) null,
       PostCode NVARCHAR(255) null,
       Tel NVARCHAR(255) null,
       Consignee NVARCHAR(255) null,
       DeliveryStatus INT null,
       PayStatus INT null,
       PayType INT null,
       SubmitTime DATETIME null,
       UserFk INT null,
       primary key (Id)
    )

    create table Comments (
        Id INT IDENTITY NOT NULL,
       ItemId INT null,
       Content NVARCHAR(MAX) null,
       AddTime DATETIME null,
       CommentType INT null,
       AuditStatus INT null,
       UserFk INT null,
       primary key (Id)
    )

    create table CommonCodes (
        Id INT IDENTITY NOT NULL,
       CommonCodeType INT null,
       CodeName NVARCHAR(255) null,
       CodeCode NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       AddTime DATETIME null,
       ParentFk INT null,
       primary key (Id)
    )

    create table Favorites (
        Id INT IDENTITY NOT NULL,
       AddTime DATETIME null,
       UserFk INT null,
       primary key (Id)
    )

    create table IntegralRecords (
        Id INT IDENTITY NOT NULL,
       Count INT null,
       BeforeChange INT null,
       Type INT null,
       ProductId INT null,
       ChangeTime DATETIME null,
       UserFk INT null,
       primary key (Id)
    )

    create table InternalMsgs (
        Id INT IDENTITY NOT NULL,
       MsgType INT null,
       Title NVARCHAR(255) null,
       FromName NVARCHAR(255) null,
       Content NVARCHAR(MAX) null,
       ReadStatus INT null,
       SendTime DATETIME null,
       FromUserFk INT null,
       ToUserFk INT null,
       primary key (Id)
    )

    create table Products (
        Id INT IDENTITY NOT NULL,
       ProductName NVARCHAR(255) null,
       ProductNo NVARCHAR(255) null,
       ProductKeyword NVARCHAR(255) null,
       Summary NVARCHAR(MAX) null,
       ProductUrl NVARCHAR(255) null,
       Content NVARCHAR(MAX) null,
       Pic NVARCHAR(255) null,
       Price DECIMAL(19,5) null,
       Freight DECIMAL(19,5) null,
       UpdateTime DATETIME null,
       ClickCount INT null,
       BuyCount INT null,
       Inventory INT null,
       FavorableCount INT null,
       PlantformName INT null,
       ShopName NVARCHAR(255) null,
       CreditRating INT null,
       Recommend BIT null,
       RecommendDays INT null,
       Status INT null,
       CompositeScore DOUBLE PRECISION null,
       ScoredCount INT null,
       DeliveryFee DECIMAL(19,5) null,
       ShippingFrom NVARCHAR(255) null,
       ProductClassFk INT null,
       ProductBrandFk INT null,
       primary key (Id)
    )

    create table ProductClasses (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Code NVARCHAR(255) null,
       ClassPic NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       AddTime DATETIME null,
       ProductCount INT null,
       ParentFk INT null,
       primary key (Id)
    )

    create table Questions (
        Id INT IDENTITY NOT NULL,
       Title NVARCHAR(255) null,
       Status INT null,
       Content NVARCHAR(MAX) null,
       AddTime DATETIME null,
       Integration INT null,
       IsNice BIT null,
       IsReward BIT null,
       AuditStatus INT null,
       QuestionClassFk INT null,
       UserFk INT null,
       primary key (Id)
    )

    create table QuestionClasses (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Descript NVARCHAR(255) null,
       PicUrl NVARCHAR(255) null,
       ParentFk INT null,
       primary key (Id)
    )

    create table SignIns (
        Id INT IDENTITY NOT NULL,
       SignInTime DATETIME null,
       SignRemark NVARCHAR(255) null,
       UserFk INT null,
       primary key (Id)
    )

    create table SysLogs (
        Id INT IDENTITY NOT NULL,
       UserName NVARCHAR(255) null,
       Content NVARCHAR(MAX) null,
       AddTime DATETIME null,
       primary key (Id)
    )

    create table Tags (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Remark NVARCHAR(255) null,
       primary key (Id)
    )

    create table Users (
        Id INT IDENTITY NOT NULL,
       LoginName NVARCHAR(255) null,
       MembershipId UNIQUEIDENTIFIER null,
       Tel NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       Gender INT null,
       BabyAge INT null,
       EmailAuthenticate BIT null,
       NickName NVARCHAR(255) null,
       HeadUrl NVARCHAR(255) null,
       Integral INT null,
       Address NVARCHAR(255) null,
       RegData DATETIME null,
       TaoBaoAccount NVARCHAR(255) null,
       TencentAccount NVARCHAR(255) null,
       SinaAccount NVARCHAR(255) null,
       XiaoNeiAccount NVARCHAR(255) null,
       Status INT null,
       AreaFk INT null,
       primary key (Id)
    )

    alter table Advertisements 
        add constraint FK3C89F447DD163D0B 
        foreign key (AdsClassFk) 
        references AdsClasses

    alter table Answers 
        add constraint FK8848AC76AB87632C 
        foreign key (UserFk) 
        references Users

    alter table Areas 
        add constraint FK1527E798FCE63FA 
        foreign key (ParentFk) 
        references Areas

    alter table Articles 
        add constraint FK359404FB9C9B9D65 
        foreign key (ArticleClassFk) 
        references ArticleClasses

    alter table ArticleClasses 
        add constraint FKED2B71093A35E5A7 
        foreign key (ParentFk) 
        references ArticleClasses

    alter table BuyOrders 
        add constraint FK307F8259AB87632C 
        foreign key (UserFk) 
        references Users

    alter table Comments 
        add constraint FK909B6703AB87632C 
        foreign key (UserFk) 
        references Users

    alter table CommonCodes 
        add constraint FKD29839755B7DF7F6 
        foreign key (ParentFk) 
        references CommonCodes

    alter table Favorites 
        add constraint FKF92D7840AB87632C 
        foreign key (UserFk) 
        references Users

    alter table IntegralRecords 
        add constraint FKD51F85E5AB87632C 
        foreign key (UserFk) 
        references Users

    alter table InternalMsgs 
        add constraint FK130DE5A8F3DFDE29 
        foreign key (FromUserFk) 
        references Users

    alter table InternalMsgs 
        add constraint FK130DE5A8F7839D66 
        foreign key (ToUserFk) 
        references Users

    alter table Products 
        add constraint FK4A7FD86AF87F9540 
        foreign key (ProductClassFk) 
        references ProductClasses

    alter table Products 
        add constraint FK4A7FD86A89DC90E1 
        foreign key (ProductBrandFk) 
        references Brands

    alter table ProductClasses 
        add constraint FK45425C328714F9F5 
        foreign key (ParentFk) 
        references ProductClasses

    alter table Questions 
        add constraint FK23DC49281A743508 
        foreign key (QuestionClassFk) 
        references QuestionClasses

    alter table Questions 
        add constraint FK23DC4928AB87632C 
        foreign key (UserFk) 
        references Users

    alter table QuestionClasses 
        add constraint FK54C3A08C6C69CAA8 
        foreign key (ParentFk) 
        references QuestionClasses

    alter table SignIns 
        add constraint FKC348B9DCAB87632C 
        foreign key (UserFk) 
        references Users

    alter table Users 
        add constraint FK2C1C7FE5EC3DAEBA 
        foreign key (AreaFk) 
        references Areas
