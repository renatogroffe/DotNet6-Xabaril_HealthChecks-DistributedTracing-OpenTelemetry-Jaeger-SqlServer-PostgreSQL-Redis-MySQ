CREATE DATABASE basecontagem;

\c basecontagem;

CREATE TABLE "HistoricoContagem" (
    "Id" SERIAL NOT NULL,
    "DataProcessamento" TIMESTAMP NOT NULL,
    "ValorAtual" INT NOT NULL,
    "Producer" VARCHAR(120) NOT NULL,
    "Kernel" VARCHAR(80) NOT NULL,
    "Framework" VARCHAR(80) NOT NULL,
    "Mensagem" VARCHAR(500) NOT NULL,
    CONSTRAINT "PK_HistoricoContagem" PRIMARY KEY ("Id")
);