use master
create database Lab02_Bai06

use Lab02_Bai06

create table MonAn
(
	IDMA char(5) primary key,
	TenMonAn varchar(50),
	IDNCC char(5),
)

create table NguoiDung
(
	IDNCC char(5) primary key,
	HoVaTen varchar(50),
	QuyenHan varchar(10),
)

alter table MonAn add foreign key (IDNCC) references NguoiDung(IDNCC)

insert into NguoiDung values('ID001', 'Nguyen A', 'No')
insert into NguoiDung values('ID002', 'Tran C', 'Yes')

insert into MonAn values('MA001', 'Bun', 'ID001')
insert into MonAn values('MA002', 'Pho', 'ID002')
insert into MonAn values('MA003', 'Com', 'ID001')

