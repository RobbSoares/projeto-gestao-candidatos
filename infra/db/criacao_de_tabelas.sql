
CREATE TABLE candidatos (
  can_id int NOT NULL AUTO_INCREMENT,
  can_nome varchar(200) COLLATE utf8_bin NOT NULL,
  can_nome_pai varchar(200) COLLATE utf8_bin NOT NULL,
  can_nome_mae varchar(200) COLLATE utf8_bin NOT NULL,
  can_senha varchar(200) COLLATE utf8_bin NOT NULL,
  can_email varchar(200) COLLATE utf8_bin NOT NULL,
  can_dt_registro date NOT NULL,
  PRIMARY KEY (can_id)
);

CREATE TABLE matriculas (
  mat_id int NOT NULL AUTO_INCREMENT,
  mat_nome VARCHAR(200) COLLATE utf8_bin NOT NULL,
  
  PRIMARY KEY (mat_id)
);

CREATE TABLE interesses (
  int_id int NOT NULL AUTO_INCREMENT,
  int_nome VARCHAR(200) COLLATE utf8_bin NOT NULL,
  int_prioridade int NOT NULL,

  PRIMARY KEY (int_id)
);

CREATE TABLE candidatos_interesses (
  cin_can_id int NOT NULL,
  cin_int_id int NOT NULL,

  CONSTRAINT pk_can_int PRIMARY KEY (cin_can_id, cin_int_id)
);

CREATE TABLE candidatos_matriculas (
  cma_can_id int NOT NULL,
  cma_mat_id int NOT NULL,

  CONSTRAINT pk_can_mat PRIMARY KEY (cma_can_id, cma_mat_id)
);

CREATE TABLE enderecos (
  end_id int NOT NULL AUTO_INCREMENT,
  end_logradouro varchar(250) COLLATE utf8_bin NOT NULL,
  end_cep varchar(10) COLLATE utf8_bin NOT NULL,
  end_numero int NOT NULL,
  end_cidade varchar(255),
  end_estado varchar(255),
  PRIMARY KEY(end_id)
);

CREATE TABLE telefones (
  tel_id int NOT NULL AUTO_INCREMENT,
  tel_numero VARCHAR(60) NOT NULL,
  tel_tipo varchar(60) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (tel_id)
);

CREATE TABLE candidatos_enderecos (
  cen_can_id int NOT NULL,
  cen_end_id int NOT NULL,

  CONSTRAINT pk_can_end PRIMARY KEY (cen_can_id, cen_end_id)
);

CREATE TABLE candidatos_telefones (
  ctl_tel_id int NOT NULL,
  ctl_can_id int NOT NULL,
  CONSTRAINT pk_can_tel PRIMARY KEY (ctl_tel_id, ctl_can_id)
);
