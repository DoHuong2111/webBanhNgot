CREATE DATABASE WebBanhNgot
GO 

USE WebBanhNgot
GO

CREATE TABLE USERS
(
	ID_US INT PRIMARY KEY IDENTITY(1,1),
	USERNAME NVARCHAR(100),
	FULL_NAME NVARCHAR(100),
	EMAIL NVARCHAR(100),
	PASSWORD_ VARCHAR(100)
)
GO

CREATE TABLE CUSTOMER
(	
	ID_CUS INT PRIMARY KEY IDENTITY(1,1),
	NAME_CUS NVARCHAR(100),
	EMAIL_CUS NVARCHAR(100),
	ADDRESS_CUS NVARCHAR(100),
	PHONE_CUS VARCHAR(15)
)
GO

CREATE TABLE TYPE_PRODUCT
(
	ID_TYPE INT PRIMARY KEY IDENTITY(1,1),
	NAME_TYPE NVARCHAR(100),
)
GO

create TABLE PRODUCT
(
	ID_PR INT PRIMARY KEY IDENTITY(1,1),
	ID_TYPE INT,
	NAME_PR NVARCHAR(255),
	UNIT NVARCHAR(20),
	PRICE DECIMAL(18,0),
	PRICE_OLD DECIMAL(18,0),
	DESCRIPTIONS NVARCHAR(255),
	IMAGE NVARCHAR(255),
	NEW bit  ,
	HOT bit  ,
	SIZE nvarchar(10)

	FOREIGN KEY (ID_TYPE) REFERENCES TYPE_PRODUCT (ID_TYPE)
)
GO

create TABLE BILL
(
	ID_BILL INT PRIMARY KEY IDENTITY(1,1),
	ID_CUS INT, 
	DATE_ORDER DATE,
	PAYMENT NVARCHAR(100),
	NOTE_BILL NVARCHAR(255),
	STATUS_BILL NVARCHAR(100)

	FOREIGN KEY (ID_CUS) REFERENCES CUSTOMER (ID_CUS)
)
GO



CREATE TABLE BILL_DETAIL
(
	ID_BILL INT, 
	ID_PR INT ,
	QUANTITY INT,
	PRICE DECIMAL(18,0)

	PRIMARY KEY (ID_BILL, ID_PR)
)
GO

CREATE TABLE PHOTO
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	NAME_PHOTO NVARCHAR(255),
	ID_PR INT

	FOREIGN KEY (ID_PR) REFERENCES PRODUCT (ID_PR)
)
GO


----INSERT DATA----------------------
--USERS-----------

INSERT INTO USERS(USERNAME, FULL_NAME, EMAIL, PASSWORD_) 
VALUES(N'Admin', 'Admin', 'huonghuong08.php@gmail.com','23456789')

select * from CUSTOMER
SELECT * FROM BILL

----CUSTOMER-------------

INSERT INTO CUSTOMER(NAME_CUS, EMAIL_CUS, ADDRESS_CUS, PHONE_CUS) VALUES
(N'Hà', 'huongnguyen@gmail.com', N'Hai Bà Trưng- Hà Nội', 0789456123)
INSERT INTO CUSTOMER( NAME_CUS, EMAIL_CUS, ADDRESS_CUS, PHONE_CUS) VALUES
( N'Hải Ngọc', 'huongnguyen@gmail.com', N'Lê thị riêng', 0123456789)
INSERT INTO CUSTOMER(NAME_CUS, EMAIL_CUS, ADDRESS_CUS, PHONE_CUS) VALUES
( N'Thanh Phương', 'huongnguyenak96@gmail.com', N'Lê Thị Riêng, Quận 1', 0987654321)
INSERT INTO CUSTOMER( NAME_CUS, EMAIL_CUS, ADDRESS_CUS, PHONE_CUS) VALUES
(N'Khoa phạm', 'khoapham@gmail.com', N'Lê thị riêng', 1234567890)
INSERT INTO CUSTOMER( NAME_CUS, EMAIL_CUS, ADDRESS_CUS, PHONE_CUS) VALUES
( N'Hương Hương', 'huongnguyenak96@gmail.com', N'Lê Thị Riêng, Quận 1', 0147258369)

------TYPE_PRODUCT----------------

INSERT INTO TYPE_PRODUCT( NAME_TYPE) VALUES
( N'Bánh mặn'),
( N'Bánh ngọt'),
( N'Bánh trái cây'),
( N'Bánh kem'),
( N'Bánh crepe'),
( N'Bánh Pizza'),
( N'Bánh su kem')

-------PRODUCT----------------

INSERT INTO PRODUCT ( NAME_PR, ID_TYPE, DESCRIPTIONS, PRICE_OLD,PRICE,IMAGE,UNIT,NEW,HOT,SIZE) VALUES
( N'Bánh Crepe Sầu riêng', 5, N'Bánh crepe sầu riêng nhà làm', 150000, 120000, '1430967449-pancake-sau-rieng-6.jpg', N'hộp',1,1,N'nhỏ'),
( N'Bánh Crepe Chocolate', 6, N'Không chỉ hấp dẫn về hình thức hay lôi cuốn về mùi vị mà món bánh Crepe socola ngàn lớp này còn chứa hàm lượng dinh dưỡng khá cao mà ít ai biết đến', 180000, 160000, 'crepe-chocolate.jpg', N'hộp',1,1,'lớn'),
( N'Bánh Crepe Sầu riêng - Chuối', 5, N'Bánh crepe sầu riêng là sự kết hợp của bột mì, trứng, bơ, sầu riêng, kem sữa tươi, sữa', 150000, 120000, 'crepe-chuoi.jpg', N'hộp',0,1,N'nhỏ'),
( N'Bánh Crepe Đào', 5, N'Crepe là một trong những loại bánh ngon rất được ưa chuộng ở các nước phương Tây', 160000, 150000, 'crepe-dao.jpg', N'hộp',0,0,N'vừa'),
( N'Bánh Crepe Dâu', 5, N'Bánh crepe dâu là sự kết hợp của bột mì, trứng, bơ, dâu, kem sữa tươi, sữa', 160000, 150000, 'crepedau.jpg', N'hộp',0,0,N'vừa'),
( N'Bánh Crepe Pháp', 5, N'Crepe là một trong những loại bánh ngon rất được ưa chuộng ở các nước phương Tây', 200000, 180000, 'crepe-phap.jpg', N'hộp',0,1,N'vừa'),
( N'Bánh Crepe Táo', 5, N'Bánh crepe táo là sự kết hợp của bột mì, trứng, bơ, táo, kem sữa tươi, sữa', 160000, 150000, 'crepe-tao.jpg', N'hộp',0,0,'nhỏ'),
( N'Bánh Crepe Trà xanh', 5, N'Bánh crepe trà xanh là sự kết hợp của bột mì, trứng, bơ, trà xanh, kem sữa tươi, sữa', 160000, 150000, 'crepe-traxanh.jpg', N'hộp',1,1,N'lớn'),
( N'Bánh Crepe Sầu riêng và Dứa', 5, N'Bánh crepe sầu riêng và dứa là sự kết hợp của bột mì, trứng, bơ, sầu riêng, dứa, kem sữa tươi, sữa', 160000, 150000, 'saurieng-dua.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh Gato Trái cây Việt Quất', 3, N'Danish việt quất được làm từ bột lên men, bánh có vị ngọt từ trái cây và được xếp cuộn lại với nhau thành ngàn lớp', 250000, 200000, '544bc48782741.png', 'cái', 0,0,N'nhỏ'),
( N'Bánh sinh nhật rau câu trái cây', 3, N'bánh là sự kết hợp nhiều loại trái cây', 200000, 180000, '210215-banh-sinh-nhat-rau-cau-body- (6).jpg', N'cái', 150000,130000,N'nhỏ'),
( N'Bánh kem Chocolate Dâu', 3, N'Cốt bánh bông lan chocolate mềm ẩm, thoáng chút vị mứt Nutella, được phủ lên lớp dâu tây tươi ngon và lớp kem béo ngậy.', 300000, 280000, 'banh kem sinh nhat.jpg', N'cái', 1,0,N'nhỏ'),
( N'Bánh kem Dâu III', 3, N'Cốt bánh bông lan chocolate mềm ẩm, thoáng chút vị mứt Nutella, được phủ lên lớp dâu tây tươi ngon và lớp kem béo ngậy.', 300000, 280000, 'Banh-kem (6).jpg', N'cái', 0,0,N'nhỏ'),
( N'Bánh kem Dâu I', 3, N'Cốt bánh bông lan chocolate mềm ẩm, thoáng chút vị mứt Nutella, được phủ lên lớp dâu tây tươi ngon và lớp kem béo ngậy.', 350000, 320000, 'banhkem-dau.jpg', N'cái', 1,0,N'nhỏ'),
( N'Bánh trái cây II', 3, N'Cốt bánh bông lan chocolate mềm ẩm, thoáng chút vị mứt Nutella, được phủ lên lớp dâu tây tươi ngon và lớp kem béo ngậy.', 150000, 120000, 'banhtraicay.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Apple Cake', 3, N'Apple Pie là một món bánh có xuất xứ từ các nước châu Âu có cách làm khá đơn giản.', 250000, 240000, 'Fruit-Cake_7979.jpg', N'cái', 0,0,N'nhỏ'),
( N'Bánh ngọt nhân cream táo', 2, N'Apple Pie là một món bánh có xuất xứ từ các nước châu Âu có cách làm khá đơn giản.', 180000, 150000, '20131108144733.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh Chocolate Trái cây', 2, N'Bánh kem SoCoLa là dòng bánh không chất bảo quản, banh kem socola được làm mới và bán hết trong ngày', 150000, 120000, 'Fruit-Cake_7976.jpg', N'hộp', 1,0,N'nhỏ'),
( N'Bánh Chocolate Trái cây II', 2, N'Bánh kem SoCoLa là dòng bánh không chất bảo quản, banh kem socola được làm mới và bán hết trong ngày', 150000, 120000, 'Fruit-Cake_7981.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Peach Cake', 2, N'Bánh kem SoCoLa là dòng bánh không chất bảo quản, banh kem socola được làm mới và bán hết trong ngày', 160000, 150000, 'Peach-Cake_3294.jpg', N'cái', 0,0,N'nhỏ'),
( N'Bánh bông lan trứng muối I', 1, N'Bánh Bông Lan Trứng Muối Phô Mai Chà Bôngi được làm từ bột mì, trứng gà, đường cát, muối iốt, lòng đỏ trứng muối,phô mai,Chà bông thịt', 160000, 150000, 'banhbonglantrung.jpg', N'hộp', 1,0,N'nhỏ'),
( N'Bánh bông lan trứng muối II', 1, N'Bánh Bông Lan Trứng Muối Phô Mai Chà Bôngi được làm từ bột mì, trứng gà, đường cát, muối iốt, lòng đỏ trứng muối,phô mai,Chà bông thịt ', 180000, 150000, 'banhbonglantrungmuoi.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh French', 1, N'French toast là một món bánh mì rán, được ngâm trong sữa và trứng rồi đem rán. ', 180000, 150000, 'banh-man-thu-vi-nhat-1.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh mì Australia', 1, N'French toast là một món bánh mì rán, được ngâm trong sữa và trứng rồi đem rán. ', 80000, 70000, 'dung-khoai-tay-lam-banh-gato-man-cuc-ngon.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh mặn thập cẩm', 1, N'French toast là một món bánh mì rán, được ngâm trong sữa và trứng rồi đem rán. ', 150000, 100000, 'Fruit-Cake.png', N'hộp', 0,0,N'nhỏ'),
( N'Bánh Muffins trứng', 1, N'Muffin là một dòng bánh ngọt được ra đời và phổ biến ở nước Pháp thơ mộng', 100000, 80000, 'maxresdefault.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh Scone Peach Cake', 1, N'Nếu từng bị mê hoặc bởi các loại tarlet ngọt thì chắn chắn bạn không thể bỏ qua những loại tarlet mặn. Ngoài hình dáng bắt mắt, lớp vở bánh giòn giòn', 120000, 0, 'Peach-Cake_3300.jpg', N'hộp', 1,0,N'nhỏ'),
( N'Bánh mì Loaf I', 1, N'Nếu từng bị mê hoặc bởi các loại tarlet ngọt thì chắn chắn bạn không thể bỏ qua những loại tarlet mặn.', 100000, 90000, 'sli12.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh kem Chocolate Dâu I', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 380000, 350000, 'sli12.jpg', N'cái', 1,0,N'nhỏ'),
( N'Bánh kem Trái cây I', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 380000, 350000, 'Fruit-Cake.jpg', N'cái', 0,0,N'nhỏ'),
( N'Bánh kem Trái cây II', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 380000, 350000, 'Fruit-Cake_7971.jpg', N'cái', 0,1,N'nhỏ'),
( N'Bánh kem Doraemon', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 280000, 250000, 'p1392962167_banh74.jpg', N'cái', 1,0,N'nhỏ'),
( N'Bánh kem Caramen Pudding', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 280000, 250000, 'Caramen-pudding636099031482099583.jpg', N'cái', 1,0,N'nhỏ'),
( N'Bánh kem Chocolate Fruit', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 320000, 300000, 'chocolate-fruit636098975917921990.jpg', N'cái', 1,0,N'nhỏ'),
( N'Bánh kem Coffee Chocolate GH6', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 320000, 300000, 'COFFE-CHOCOLATE636098977566220885.jpg', N'cái', 0,0,N'nhỏ'),
( N'Bánh kem Mango Mouse', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 320000, 300000, 'mango-mousse-cake.jpg', N'cái', 1,0,N'nhỏ'),
( N'Bánh kem Matcha Mouse', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 350000, 330000, 'MATCHA-MOUSSE.jpg', N'cái', 0,1,N'nhỏ'),
( N'Bánh kem Flower Fruit', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 350000, 330000, 'flower-fruits636102461981788938.jpg', N'cái', 0,1,N'nhỏ'),
( N'Bánh kem Strawberry Delight', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 350000, 330000, 'strawberry-delight636102445035635173.jpg', N'cái', 0,1,N'nhỏ'),
( N'Bánh kem Raspberry Delight', 4, N'Với người Việt Nam thì bánh ngọt nói chung đều hay được quy về bánh bông lan – một loại tráng miệng bông xốp, ăn không hoặc được phủ kem lên thành bánh kem.', 350000, 330000, 'raspberry.jpg', N'cái', 0,0,N'nhỏ'),
( N'Beefy Pizza', 6, N'Thịt bò xay, ngô, sốt BBQ, phô mai mozzarella', 150000, 130000, '40819_food_pizza.jpg', N'cái', 0,0,N'nhỏ'),
( N'Hawaii Pizza', 6, N'Sốt cà chua, ham , dứa, pho mai mozzarella', 120000, 100000, 'hawaiian paradise_large-900x900.jpg', N'cái', 1,0,N'nhỏ'),
( N'Smoke Chicken Pizza', 6, N'Gà hun khói,nấm, sốt cà chua, pho mai mozzarella.', 120000, 100000, 'chicken black pepper_large-900x900.jpg', N'cái', 0,0,N'nhỏ'),
( N'Sausage Pizza', 6, N'Xúc xích klobasa, Nấm, Ngô, sốtcà chua, pho mai Mozzarella.', 120000, 100000, 'pizza-miami.jpg', N'cái', 0,1,N'nhỏ'),
( N'Ocean Pizza', 6, N'Tôm , mực, xào cay,ớt xanh, hành tây, cà chua, phomai mozzarella.', 120000, 100000, 'seafood curry_large-900x900.jpg', N'cái', 0,0,N'nhỏ'),
( N'All Meaty Pizza', 6, N'Ham, bacon, chorizo, pho mai mozzarella.', 140000, 120000, 'all1).jpg', N'cái', 0,0,N'nhỏ'),
( N'Tuna Pizza', 6, N'Cá Ngừ, sốt Mayonnaise,sốt càchua, hành tây, pho mai Mozzarella', 140000, 120000, '54eaf93713081_-_07-germany-tuna.jpg', N'cái', 0,0,N'nhỏ'),
( N'Bánh su kem nhân dừa', 7, N'Bánh su kem là món bánh ngọt ở dạng kem được làm từ các nguyên liệu như bột mì, trứng, sữa, bơ.... ', 120000, 100000, 'maxresdefault.jpg', N'cái', 0,0,N'nhỏ'),
( N'Bánh su kem sữa tươi', 7, N'Bánh su kem là món bánh ngọt ở dạng kem được làm từ các nguyên liệu như bột mì, trứng, sữa, bơ.... ', 120000, 100000, 'sukem.jpg', N'cái', 0,0,N'nhỏ'),
( N'Bánh su kem sữa tươi chiên giòn', 7, N'Bánh su kem là món bánh ngọt ở dạng kem được làm từ các nguyên liệu như bột mì, trứng, sữa, bơ.... ', 150000, 120000, '1434429117-banh-su-kem-chien-20.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh su kem dâu sữa tươi', 7, N'Bánh su kem là món bánh ngọt ở dạng kem được làm từ các nguyên liệu như bột mì, trứng, sữa, bơ.... ', 150000, 120000, 'sukemdau.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh su kem bơ sữa tươi', 7, N'Bánh su kem là món bánh ngọt ở dạng kem được làm từ các nguyên liệu như bột mì, trứng, sữa, bơ.... ', 150000, 120000, 'He-Thong-Banh-Su-Singapore-Chewy-Junior.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh su kem nhân trái cây sữa tươi', 7, N'Bánh su kem là món bánh ngọt ở dạng kem được làm từ các nguyên liệu như bột mì, trứng, sữa, bơ.... ', 150000, 120000, 'foody-banh-su-que-635930347896369908.jpg', N'hộp', 1,0,N'nhỏ'),
( N'Bánh su kem cà phê', 7, N'Bánh su kem là món bánh ngọt ở dạng kem được làm từ các nguyên liệu như bột mì, trứng, sữa, bơ.... ', 150000, 120000, 'banh-su-kem-ca-phe-1.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh su kem phô mai', 7, N'Bánh su kem là món bánh ngọt ở dạng kem được làm từ các nguyên liệu như bột mì, trứng, sữa, bơ.... ', 150000, 120000, '50020041-combo-20-banh-su-que-pho-mai-9.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh su kem sữa tươi chocolate', 7, N'Bánh su kem là món bánh ngọt ở dạng kem được làm từ các nguyên liệu như bột mì, trứng, sữa, bơ.... ', 150000, 120000, 'combo-20-banh-su-que-kem-sua-tuoi-phu-socola.jpg', N'hộp', 1,0,N'nhỏ'),
( N'Bánh Macaron Pháp', 2, N'Thưởng thức macaron, người ta có thể tìm thấy từ những hương vị truyền thống như mâm xôi', 200000, 180000, 'Macaron9.jpg', N'hỘP', 0,0,N'nhỏ'),
( N'Bánh Tiramisu - Italia', 2, N'Chỉ cần cắn một miếng, bạn sẽ cảm nhận được tất cả các hương vị đó hòa quyện cùng một chính vì thế người ta còn ví món bánh này là Thiên đường trong miệng của bạn', 200000, 0, '234.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh Táo - Mỹ', 2, N'Bánh táo Mỹ với phần vỏ bánh mỏng, giòn mềm, ẩn chứa phần nhân táo thơm ngọt', 200000, 150000, '1234.jpg', N'hộp', 0,0,N'nhỏ'),
( N'Bánh Cupcake - Anh Quốc', 6, N'Những chiếc cupcake có cấu tạo gồm phần vỏ bánh xốp mịn và phần kem trang trí bên trên', 150000, 120000, 'cupcake.jpg', N'cái', 1,0,N'nhỏ'),
( N'Bánh Sachertorte', 6, N'Sachertorte là một loại bánh xốp được tạo ra bởi loại&nbsp;chocholate&nbsp', 250000, 220000, '111.jpg', N'cái', 0,0,N'nhỏ');


----BILL----------------

INSERT INTO BILL ( ID_CUS,DATE_ORDER,PAYMENT,NOTE_BILL,STATUS_BILL) VALUES
( 4, '2017-03-23',  'COD', N'Không có ghi chú',N'Hoàn thành'),
( 3, '2017-03-21',  'ATM', N'Vui lòng giao hàng trước 5h',N'Hoàn thành'),
( 2, '2017-03-21',  'COD', N'Vui lòng chuyển đúng hạn',N'Chưa giao hàng'),
( 1, '2017-03-21', 'COD', N'Vui lòng chuyển đúng hạn',N'Đang giao hàng'),
( 5, '2017-03-24',  'COD', N'Không có ghi chú',N'Hoàn thành');


--------- BILL_DETAIL--------

INSERT INTO BILL_DETAIL ( ID_BILL,ID_PR,QUANTITY, PRICE) VALUES
(4, 1, 5, 220000),
(4, 2, 1, 160000),
(3, 60, 1, 200000),
(3, 59, 1, 200000),
(2, 60, 2, 200000),
(2, 61, 1, 120000),
(1, 61, 1, 120000),
(1, 57, 2, 150000)

select * from product join type_product on product.id_type = type_product.id_type where name_type like N'%bánh su kem%' and (product.price between 0 and 100000000)