CREATE TABLE [dbo].[Products] (
    [id]          INT             IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (100)  NOT NULL,
    [description] NVARCHAR (500)  NOT NULL,
    [price]       DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Images] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [url]        NVARCHAR (200) NOT NULL,
    [product_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([product_id]) REFERENCES [dbo].[Products] ([id])
);

CREATE TABLE [dbo].[Promocodes] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [code]         NVARCHAR (50) NOT NULL,
    [discount]     INT           NOT NULL,
    [count]        INT           NOT NULL,
    [used_count]   INT           DEFAULT ((0)) NOT NULL,
    [expires_date] DATETIME      NOT NULL,
    [is_used]      BIT           DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [AK_Code_Promocodes] UNIQUE NONCLUSTERED ([code] ASC)
);

CREATE TABLE [dbo].[ShoppingCarts] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [email]        NVARCHAR (50) NOT NULL,
    [promocode_id] INT           NULL,
    [is_closed]    BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([promocode_id]) REFERENCES [dbo].[Promocodes] ([id])
);

CREATE TABLE [dbo].[ProductsShoppingCarts] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [product_id] INT NOT NULL,
    [cart_id]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([product_id]) REFERENCES [dbo].[Products] ([id]),
    FOREIGN KEY ([cart_id]) REFERENCES [dbo].[ShoppingCarts] ([id])
);

INSERT INTO [dbo].[Products] ([name], [description], [price]) VALUES (N'Пляжная туника', N'Пляжная туника oversize из стрейч-сетки, с завышенной талией на шнуровке, v-образным вырезом, коротким рукавом и капюшоном.', CAST(482.00 AS Decimal(18, 2)));
INSERT INTO [dbo].[Products] ([name], [description], [price]) VALUES (N'Трендовые укороченные брюки', N'Трендовые брюки, укороченной модели низкой посадки со стрелками, прорезными карманами спереди и карманами-обманками сзади.', CAST(676.00 AS Decimal(18, 2)));
INSERT INTO [dbo].[Products] ([name], [description], [price]) VALUES (N'Нежный шелковый платок', N'Шелковый платок нежных оттенков с цветочным принтом.', CAST(418.00 AS Decimal(18, 2)));
INSERT INTO [dbo].[Products] ([name], [description], [price]) VALUES (N'Легкий шерстяной кардиган', N'Оригинальный кардиган из шерсти с воротником-стойкой и двумя накладными карманами.', CAST(938.00 AS Decimal(18, 2)));
INSERT INTO [dbo].[Products] ([name], [description], [price]) VALUES (N'Юбка макси штапель', N'Летняя юбка-макси из штапеля на запáх с втачным поясом и ярким принтом.', CAST(482.00 AS Decimal(18, 2)));
INSERT INTO [dbo].[Products] ([name], [description], [price]) VALUES (N'Легкое шифоновое платье', N'Легкое платье-макси из шифона на подкладе с резинкой на поясе и рюшами на горловине. ', CAST(952.00 AS Decimal(18, 2)));
INSERT INTO [dbo].[Products] ([name], [description], [price]) VALUES (N'Легкое шифоновое платье', N'Легкое летнее платье из шифона на подкладе, с резинкой на поясе и рюшами на горловине. ', CAST(952.00 AS Decimal(18, 2)));
INSERT INTO [dbo].[Products] ([name], [description], [price]) VALUES (N'Спортивный костюм оборки', N'Брючный спортивный костюм с оборками: укороченный свитшот с рукавом ½, расширенной горловиной и декоративным элементом на груди, брюки с эластичными элементами на поясе и манжетах, прорезными карманами по бокам и накладными карманами сзади.', CAST(900.00 AS Decimal(18, 2)));

INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21556/simple/origins/21556_1.jpg', 1);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21556/simple/origins/21556_2.jpg', 1);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21556/simple/origins/21556_3.jpg', 1);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21554/simple/origins/21554_1.jpg', 2);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21554/simple/origins/21554_2.jpg', 2);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21554/simple/origins/21554_3.jpg', 2);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21552/simple/origins/21552_1.jpg', 3);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21553/simple/origins/21553_1.jpg', 4);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21553/simple/origins/21553_2.jpg', 4);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21553/simple/origins/21553_3.jpg', 4);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21430/simple/origins/21430_1.jpg', 5);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21430/simple/origins/21430_2.jpg', 5);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21430/simple/origins/21430_3.jpg', 5);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21416/simple/origins/21416_1.jpg', 6);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21416/simple/origins/21416_2.jpg', 6);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21416/simple/origins/21416_3.jpg', 6);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21411/simple/origins/21411_1.jpg', 7);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21411/simple/origins/21411_2.jpg', 7);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21411/simple/origins/21411_3.jpg', 7);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21673/simple/origins/21673_1.jpg', 8);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21673/simple/origins/21673_2.jpg', 8);
INSERT INTO [dbo].[Images] ([url], [product_id]) VALUES (N'https://gepur.com/products/25000/21673/simple/origins/21673_3.jpg', 8);

INSERT INTO [dbo].[Promocodes] ([[code], [discount], [count], [used_count], [expires_date], [is_used]) VALUES (N'source', 20, 10, 0, N'2017-07-10 00:00:00', 0);