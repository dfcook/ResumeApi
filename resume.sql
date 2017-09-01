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
    role character varying(100) COLLATE pg_catalog."default",
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

-- Table: public.links

-- DROP TABLE public.links;

CREATE SEQUENCE public.link_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.link_id_seq
    OWNER TO postgres;

CREATE TABLE public.links
(
    id integer NOT NULL DEFAULT nextval('link_id_seq'::regclass),
    resume_id integer NOT NULL,    
    icon character varying(50) COLLATE pg_catalog."default" NOT NULL,
    url character varying(200) COLLATE pg_catalog."default" NOT NULL,    
    CONSTRAINT link_pkey PRIMARY KEY (id),
    CONSTRAINT fk_link FOREIGN KEY (resume_id)
        REFERENCES public.resume (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.links
    OWNER to postgres;

-- data

INSERT INTO public.resume(
	user_name, first_name, last_name, company_name, summary)
	VALUES ('dfcook', 'Daniel', 'Cook', 'Dota IT Services Ltd', 'A senior developer with 20 years'' experience including 16 years in .NET development for both the desktop and the Web. Familiar with both server and client-side paradigms including practical experience in modern JavaScript frameworks. Experienced in object-oriented and functional design and patterns. Strong SQL skills including query performance analysis.');

INSERT INTO public.key_skill(
	resume_id, description)
	VALUES (1, 'C#, VB.NET, .NET Framework');
    
INSERT INTO public.key_skill(
	resume_id, description)    
    VALUES (1, 'System Analysis and Design, including application of functional and OO patterns');
    
INSERT INTO public.key_skill(
	resume_id, description)    
    VALUES (1, 'ASP.NET MVC & Web API');
    
INSERT INTO public.key_skill(
	resume_id, description)    
    VALUES (1, 'JavaScript (ES5/6), Typescript, Coffeescript');
    
INSERT INTO public.key_skill(
	resume_id, description)    
    VALUES (1, 'VueJS/Angular/React/Knockout');
    
INSERT INTO public.key_skill(
	resume_id, description)    
    VALUES (1, 'Webpack/NPM/Node');
    
INSERT INTO public.key_skill(
	resume_id, description)    
    VALUES (1, 'Silverlight (MVVM, Prism)');
    
INSERT INTO public.key_skill(
	resume_id, description)    
    VALUES (1, 'WCF/Remoting');
    
INSERT INTO public.key_skill(
	resume_id, description)    
    VALUES (1, 'HTML5, CSS');
    
INSERT INTO public.key_skill(
	resume_id, description)    
    VALUES (1, 'SQL Server – Stored Procedures, Views, Triggers, Performance tuning');

INSERT INTO public.industry_knowledge(
	resume_id, description)    
    VALUES (1, 'Investment Banking – Convertible Bond pricing, trading and research systems.  Trading FOBO, reconciliation and exception workflow management');

INSERT INTO public.industry_knowledge(
	resume_id, description)    
    VALUES (1, 'Financial Services - Home Insurance\Loans');    

INSERT INTO public.industry_knowledge(
	resume_id, description)    
    VALUES (1, 'Retail');    

INSERT INTO public.industry_knowledge(
	resume_id, description)    
    VALUES (1, 'Mail');        

INSERT INTO public.education(
	resume_id, from_year, to_year, establishment, qualifications)    
    VALUES (1, 1986, 1993, 'Kirkham Grammar School', '4 A-Levels and 9 GCSE''s');

INSERT INTO public.education(
	resume_id, from_year, to_year, establishment, qualifications)    
    VALUES (1, 1993, 1996, 'Kirkham Grammar School', 'Degree (2:1) in English Literature / Philosophy');

INSERT INTO public.links (resume_id, icon, url)
  VALUES (1, 'fa-envelope', 'mailto: dota_it@hotmail.co.uk');

INSERT INTO public.links (resume_id, icon, url)
  VALUES (1, 'fa-linkedin', 'https://uk.linkedin.com/in/daniel-cook-938529110');

INSERT INTO public.links (resume_id, icon, url)
  VALUES (1, 'fa-github', 'https://github.com/dfcook');