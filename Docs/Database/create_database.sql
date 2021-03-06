CREATE DATABASE jurify_autenticador
    WITH OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

CREATE EXTENSION IF NOT EXISTS pgcrypto;

create table escritorios(
	codigo uuid not null primary key default gen_random_uuid(),
	razao_social varchar(300) not null,
	nome_fantasia varchar(300) not null,
	cnpj varchar(20) not null,
	apagado boolean default false
);

create table especialidades(
	codigo uuid not null primary key default gen_random_uuid(),
	nome varchar(100) not null,
	descricao varchar(255) not null,
	apagado boolean default false
);

create table especialidades_escritorio(
	codigo uuid not null primary key default gen_random_uuid(),
	codigo_escritorio uuid references escritorios(codigo),
	codigo_especialidade uuid references especialidades(codigo),
	apagado boolean default false
);

create table enderecos(
	codigo uuid not null primary key default gen_random_uuid(),
	codigo_escritorio uuid references escritorios(codigo),
	cep varchar(8) not null,
	rua varchar(300) not null,
	numero varchar(20) not null,
	complemento varchar(255) not null,
	bairro varchar(200) not null,
	cidade varchar(200) not null,
	estado varchar(100) not null,
	latitude varchar(10) not null,
	longitude varchar(10) not null
);

create table usuarios_escritorio(
	codigo uuid not null primary key default gen_random_uuid(),
	codigo_escritorio uuid not null references escritorios(codigo),
	username varchar(150) not null,
	password text not null,
	nome varchar(100) not null,
	sobrenome varchar(255) not null,
	permissoes jsonb not null,
	numero_oab text null,
	codigo_uf numeric(2) null, 
	caminho_imagem text null,
	apagado boolean default false
);

create table usuarios_cliente(
	codigo uuid not null primary key default gen_random_uuid(),
	username varchar(50) not null,
	password text not null,
	nome varchar(100) not null,
	sobrenome varchar(250) not null,
	permissoes jsonb not null,
	apagado boolean default false
);