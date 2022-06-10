BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "macler" (
	"Name"	character(50) NOT NULL,
	"Address"	character(50) NOT NULL,
	"Birthday"	date NOT NULL,
	"ID"	integer NOT NULL,
	CONSTRAINT "macler_pk" PRIMARY KEY("ID")
);
CREATE TABLE IF NOT EXISTS "goods" (
	"Name"	character(50) NOT NULL,
	"Type"	character(50) NOT NULL,
	"Price"	decimal(100 , 1) NOT NULL,
	"Supplier"	character(50) NOT NULL,
	"store_Date"	character(50) NOT NULL,
	"Amount"	integer NOT NULL,
	"ID"	integer NOT NULL,
	"deals_ID"	integer NOT NULL,
	"macler_ID"	integer NOT NULL,
	CONSTRAINT "goods_macler" FOREIGN KEY("macler_ID") REFERENCES "macler"("ID"),
	CONSTRAINT "goods_deals" FOREIGN KEY("deals_ID") REFERENCES "deals"("ID"),
	CONSTRAINT "goods_pk" PRIMARY KEY("ID")
);
CREATE TABLE IF NOT EXISTS "deals" (
	"Date"	date NOT NULL,
	"Name"	character(50) NOT NULL,
	"Type"	character(50) NOT NULL,
	"Amount"	integer NOT NULL,
	"Macler"	character(50) NOT NULL,
	"Customer"	character(50) NOT NULL,
	"ID"	integer NOT NULL,
	"macler_ID"	integer NOT NULL,
	CONSTRAINT "deals_macler" FOREIGN KEY("macler_ID") REFERENCES "macler"("ID"),
	CONSTRAINT "deals_pk" PRIMARY KEY("ID")
);
INSERT INTO "macler" VALUES ('Alex','Chapaeva 10','20.12.2001',1);
INSERT INTO "macler" VALUES ('Ilya','Pomoyka','14.04.1995',2);
INSERT INTO "macler" VALUES ('Andrew','Chinatown','10.08.2000',3);
INSERT INTO "macler" VALUES ('Volodar','Putin Square','25.01.2002',4);
INSERT INTO "goods" VALUES ('Chanel','Toilet Water',500,'Gucci','01.01.2023',20,1,1,1);
INSERT INTO "goods" VALUES ('Lacoste','Toilet Water',400,'Someone','25.03.2023',5,2,2,3);
INSERT INTO "deals" VALUES ('12.12.2022','Chanel','Toilet Water',20,'Alex','Customer',1,1);
INSERT INTO "deals" VALUES ('20.05.2022','Lacoste','Toilet Water',5,'Andrew','Someone',2,3);
COMMIT;
