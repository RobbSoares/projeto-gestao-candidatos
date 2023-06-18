
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

CREATE TABLE matricula (
  can_id int NOT NULL,
  cur_id int NOT NULL,
  
  CONSTRAINT fk_can FOREIGN KEY (can_id) REFERENCES candidatos (can_id),
  CONSTRAINT fk_cur FOREIGN KEY (cur_id) REFERENCES cursos (cur_id)
);

CREATE TABLE interesses (
  cur_int_id int NOT NULL,
  can_int_id int NOT NULL,

  CONSTRAINT fk_can_int FOREIGN KEY (can_int_id) REFERENCES candidatos (can_id),
  CONSTRAINT fk_cur_int FOREIGN KEY (cur_int_id) REFERENCES cursos (cur_id)
);

CREATE TABLE cursos (
  cur_id INT NOT NULL,
  cur_nome VARCHAR(200) COLLATE utf8_bin NOT NULL,
  cur_descricao VARCHAR(500) COLLATE utf8_bin NOT NULL
);

CREATE TABLE endereco (
  end_id int NOT NULL AUTO_INCREMENT,
  end_logradouro varchar(250) COLLATE utf8_bin NOT NULL,
  end_cep varchar(10) COLLATE utf8_bin NOT NULL,
  end_numero int NOT NULL,
  PRIMARY KEY(end_id)
);

CREATE TABLE cidades (
  cid_id int(100) NOT NULL,
  cid_nome varchar(100) COLLATE utf8_bin NOT NULL,
  cid_est_id int(100) NOT NULL
);

CREATE TABLE estados (
  est_id int(100) NOT NULL,
  est_nome varchar(100) COLLATE utf8_bin NOT NULL,
  est_capital_id int(100) NOT NULL,
  est_sigla varchar(10) COLLATE utf8_bin NOT NULL
);

CREATE TABLE telefones (
  tel_id int NOT NULL,
  tel_numero int NOT NULL,
  tel_tipo varchar(60) COLLATE utf8_bin NOT NULL
);

CREATE TABLE candidatos_enderecos (
  cen_can_id int NOT NULL,
  cen_end_id int NOT NULL
);

CREATE TABLE candidatos_telefones (
  ctl_tel_id int NOT NULL,
  ctl_can_id int NOT NULL
);





ALTER TABLE cidades
  ADD PRIMARY KEY (cid_id),
  ADD KEY fk_cid_est (cid_est_id);

ALTER TABLE endereco
  ADD PRIMARY KEY (end_id);

ALTER TABLE cursos
  ADD PRIMARY KEY (cur_id);

ALTER TABLE cursos_interessados
  ADD PRIMARY KEY (cin_id);

ALTER TABLE estados
  ADD PRIMARY KEY (est_id),
  ADD KEY fk_est_cid_id (est_capital_id);

ALTER TABLE telefones
  ADD PRIMARY KEY (tel_id);

ALTER TABLE cursos_interessados
  MODIFY cur_id int NOT NULL AUTO_INCREMENT;

ALTER TABLE cursos
  MODIFY cin_id int NOT NULL AUTO_INCREMENT;

ALTER TABLE endereco
  MODIFY end_id int NOT NULL AUTO_INCREMENT;

ALTER TABLE telefones
  MODIFY tel_id int NOT NULL AUTO_INCREMENT;

ALTER TABLE cidades
  ADD CONSTRAINT fk_cid_est FOREIGN KEY (cid_est_id) REFERENCES estados (est_id);

ALTER TABLE estados
  ADD CONSTRAINT fk_est_cid FOREIGN KEY (est_capital_id) REFERENCES cidades (cid_id);

ALTER TABLE candidatos_enderecos
  ADD CONSTRAINT pk_can_end PRIMARY KEY (cen_can_id, cen_end_id);

ALTER TABLE candidatos_enderecos
  ADD CONSTRAINT fk_cen_can FOREIGN KEY (cen_can_id) REFERENCES candidatos (can_id);

ALTER TABLE candidatos_enderecos
  ADD CONSTRAINT fk_cen_end FOREIGN KEY (cen_end_id) REFERENCES enderecos (end_id);

ALTER TABLE candidatos_telefones
  ADD CONSTRAINT pk_can_tel PRIMARY KEY (ctl_can_id, ctl_tel_id);

ALTER TABLE candidatos_telefones
  ADD CONSTRAINT fk_ctl_tel FOREIGN KEY (ctl_tel_id) REFERENCES telefones (tel_id);
  
ALTER TABLE candidatos_telefones
  ADD CONSTRAINT fk_ctl_can FOREIGN KEY (ctl_can_id) REFERENCES candidatos (can_id);

