CREATE TABLE IF NOT EXISTS public.cliente
(
    id SERIAL PRIMARY KEY,
    lime integer NOT NULL,
    saldo integer NOT NULL
);

CREATE TABLE IF NOT EXISTS public.Transacoes
(
    Id SERIAL PRIMARY KEY,
    valor integer NOT NULL,
    tipo character(1) NOT NULL,
    descricao character varying(10) NOT NULL,
    data timestamp with time zone NOT NULL,
    ClienteId integer NOT NULL,
    CONSTRAINT fk_cliente_id FOREIGN KEY (ClienteId) REFERENCES public.cliente(id)
);

INSERT INTO public.cliente (lime, saldo) VALUES
(100000, 0),
(80000, 0),
(1000000, 0),
(10000000, 0),
(500000, 0);

