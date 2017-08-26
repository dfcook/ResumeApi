-- SCHEMA: public

-- DROP SCHEMA public ;

CREATE SCHEMA public
    AUTHORIZATION postgres;

COMMENT ON SCHEMA public
    IS 'standard public schema';

GRANT ALL ON SCHEMA public TO postgres;

GRANT ALL ON SCHEMA public TO PUBLIC;

-- Table: public.resume

-- DROP TABLE public.resume;

CREATE SEQUENCE public.resume_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.resume_id_seq
    OWNER TO postgres;

CREATE TABLE public.resume
(
    id integer NOT NULL DEFAULT nextval('resume_id_seq'::regclass),
    user_name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    first_name character varying(100) COLLATE pg_catalog."default" NOT NULL,
    last_name character varying(100) COLLATE pg_catalog."default" NOT NULL,
    company_name character varying(100) COLLATE pg_catalog."default",
    summary character varying(1000) COLLATE pg_catalog."default",
    CONSTRAINT resume_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.resume
    OWNER to postgres;

-- Table: public.key_skill

-- DROP TABLE public.key_skill;

CREATE SEQUENCE public.key_skill_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.key_skill_id_seq
    OWNER TO postgres;

CREATE TABLE public.key_skill
(
    id integer NOT NULL DEFAULT nextval('key_skill_id_seq'::regclass),
    resume_id integer NOT NULL,
    description character varying(200) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT key_skill_pkey PRIMARY KEY (id),
    CONSTRAINT fk_key_skill FOREIGN KEY (resume_id)
        REFERENCES public.resume (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.key_skill
    OWNER to postgres;

-- Table: public.industry_knowledge

-- DROP TABLE public.industry_knowledge;

CREATE SEQUENCE public.industry_knowledge_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.industry_knowledge_id_seq
    OWNER TO postgres;

CREATE TABLE public.industry_knowledge
(
    id integer NOT NULL DEFAULT nextval('industry_knowledge_id_seq'::regclass),
    resume_id integer NOT NULL,
    description character varying(200) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT industry_knowledge_pkey PRIMARY KEY (id),
    CONSTRAINT fk_industry_knowledge FOREIGN KEY (resume_id)
        REFERENCES public.resume (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.industry_knowledge
    OWNER to postgres;

-- Table: public.education

-- DROP TABLE public.education;

CREATE SEQUENCE public.education_id_seq
    INCREMENT 1
    START 2
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.education_id_seq
    OWNER TO postgres;

CREATE TABLE public.education
(
    id integer NOT NULL DEFAULT nextval('education_id_seq'::regclass),
    resume_id integer NOT NULL,
    from_year integer NOT NULL,
    to_year integer,
    establishment character varying(200) COLLATE pg_catalog."default" NOT NULL,
    qualifications character varying(500) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT education_pkey PRIMARY KEY (id),
    CONSTRAINT fk_education FOREIGN KEY (resume_id)
        REFERENCES public.resume (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.education
    OWNER to postgres;

-- Table: public.experience

-- DROP TABLE public.experience;

CREATE SEQUENCE public.experience_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.experience_id_seq
    OWNER TO postgres;

CREATE TABLE public.experience
(
    id integer NOT NULL DEFAULT nextval('experience_id_seq'::regclass),
    resume_id integer NOT NULL,
    from_date date NOT NULL,
    to_date date,
    role character varying(100) COLLATE pg_catalog."default" NOT NULL,
    company_name character varying(100) COLLATE pg_catalog."default" NOT NULL,
    location character varying(100) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT experience_pkey PRIMARY KEY (id),
    CONSTRAINT fk_experience FOREIGN KEY (resume_id)
        REFERENCES public.resume (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.experience
    OWNER to postgres;