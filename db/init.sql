-- Table: public.clinic

DROP TABLE IF EXISTS public.clinic;

CREATE TABLE public.clinic
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    name text COLLATE pg_catalog."default",
    address text COLLATE pg_catalog."default",
    CONSTRAINT clinic_pkey PRIMARY KEY (Id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.clinic
    OWNER to postgres;

INSERT INTO public.clinic (name, address) VALUES
  ('Dub Lab', '120 Rue des rondes, Poissy 78000'),
  ('Fun Lab', '95 Rue des mans, Achères 63000'),
  ('Fream Health', '5 Rue des maris, Bagneux 92000'),
  ('Lex Lab', '8 Rue des frères, Bagneux 92000');