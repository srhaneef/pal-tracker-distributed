create table stories (
     id         bigint not null auto_increment,
     project_id bigint,
     name       VARCHAR(255),

     primary key (id)
)
engine = innodb
default charset = UTF8MB4;