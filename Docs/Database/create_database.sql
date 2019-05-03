CREATE DATABASE jurify_autenticador
    WITH OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

CREATE EXTENSION pgcrypto;

CREATE TABLE office_users(
    id UUID NOT NULL PRIMARY KEY DEFAULT gen_random_uuid(),
    username VARCHAR(150) NOT NULL,
    password TEXT NOT NULL,
    office_id UUID NOT NULL,
    first_name VARCHAR(100) NOT NULL,
    last_name  VARCHAR(250) NOT NULL,
    email VARCHAR(150) NOT NULL,
    phone_ddd NUMERIC(2,0),
    phone_number NUMERIC(9,0),
    claims jsonb NOT NULL,
    deleted boolean DEFAULT false
);

CREATE TABLE offices(
    id uuid NOT NULL PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(100) NOT NULL,
    latitude NUMERIC(11,8),
    longitude NUMERIC(11,8),
    deleted boolean NOT NULL DEFAULT false
);

CREATE TABLE client_users(
	id UUID NOT NULL PRIMARY KEY DEFAULT gen_random_uuid(),
    username VARCHAR(50) NOT NULL,
    password TEXT NOT NULL,
    first_name VARCHAR(100) NOT NULL,
    last_name  VARCHAR(250) NOT NULL,
    email VARCHAR(150) NOT NULL,
    phone_ddd NUMERIC(2,0),
    phone_number NUMERIC(9,0),
    claims jsonb NOT NULL,
    deleted boolean DEFAULT false
);