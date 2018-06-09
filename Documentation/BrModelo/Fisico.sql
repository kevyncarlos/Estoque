-- Geração de Modelo físico
-- Sql ANSI 2003 - brModelo.



CREATE TABLE Permissoes (
PermissaoId INTEGER PRIMARY KEY,
Permissao VARCHAR(50),
Ativo INTEGER
)

CREATE TABLE Empresas (
EmpresaId INTEGER PRIMARY KEY,
Empresa VARCHAR(100),
Cidade VARCHAR(50),
Descricao VARCHAR(200),
Ativo VARCHAR(10)
)

CREATE TABLE ProdutosOrdens (
ProdutoOrdemId INTEGER PRIMARY KEY,
OrdemServicoId INTEGER,
ProdutoId INTEGER,
Motivo VARCHAR(150),
DataHora DATETIME
)

CREATE TABLE UsuarioPermissoes (
UsuarioPermissaoId INTEGER PRIMARY KEY,
PermissaoId INTEGER,
TipoUsuarioId INTEGER,
FOREIGN KEY(PermissaoId) REFERENCES Permissoes (PermissaoId)
)

CREATE TABLE TipoUsuarios (
TipoUsuarioId INTEGER PRIMARY KEY,
Tipo VARCHAR(50),
Ativo INTEGER
)

CREATE TABLE TipoOrdemServicos (
TipoOrdemServicoId INTEGER PRIMARY KEY,
Tipo VARCHAR(50),
Ativo INTEGER
)

CREATE TABLE Usuarios (
UsuarioId INTEGER PRIMARY KEY,
TipoUsuarioId INTEGER,
EmpresaId INTEGER,
Nome VARCHAR(150),
Matricula VARCHAR(5),
Senha VARCHAR(15),
Email VARCHAR(50),
Ativo INTEGER,
UltimoAcesso DATETIME,
DataCad DATETIME,
FOREIGN KEY(TipoUsuarioId) REFERENCES TipoUsuarios (TipoUsuarioId),
FOREIGN KEY(EmpresaId) REFERENCES Empresas (EmpresaId)
)

CREATE TABLE LogOrdens (
LogOrdemId INTEGER PRIMARY KEY,
OrdemServicoId INTEGER,
Data DATETIME,
Descricao VARCHAR(150),
StatusOrdem INTEGER
)

CREATE TABLE CompraProdutos (
CompraProdutoId INTEGER PRIMARY KEY,
CompraId INTEGER,
ProdutoId INTEGER,
QtdProduto INTEGER,
Metro DECIMAL(10),
Unidade INTEGER,
Valor DECIMAL(10)
)

CREATE TABLE Compras (
CompraId INTEGER PRIMARY KEY,
EmpresaId INTEGER,
FornecedorId INTEGER,
DataCompra DATETIME,
Total DECIMAL(10),
FOREIGN KEY(EmpresaId) REFERENCES Empresas (EmpresaId)
)

CREATE TABLE Fornecedores (
FornecedorId INTEGER PRIMARY KEY,
Endereco VARCHAR(100),
Telefone VARCHAR(16),
Fornecedor VARCHAR(150),
CNPJ VARCHAR(18),
Ativo INTEGER
)

CREATE TABLE Produtos (
ProdutoId INTEGER PRIMARY KEY,
PrateleiraId INTEGER,
Produto VARCHAR(150),
Ativo INTEGER
)

CREATE TABLE Prateleiras (
PrateleiraId INTEGER PRIMARY KEY,
CategoriaId INTEGER,
Descricao VARCHAR(50)
)

CREATE TABLE Categorias (
CategoriaId INTEGER PRIMARY KEY,
TipoProdutoId INTEGER,
Categoria VARCHAR(50),
Ativo INTEGER
)

CREATE TABLE TipoProdutos (
TipoProdutoId INTEGER PRIMARY KEY,
Tipo VARCHAR(10),
Ativo INTEGER
)

CREATE TABLE OrdemServicos (
OrdemServicoId INTEGER PRIMARY KEY,
TipoOrdemServicoId INTEGER,
UsuarioId INTEGER,
Descricao VARCHAR(250),
Cliente VARCHAR(150),
Status INTEGER,
FOREIGN KEY(TipoOrdemServicoId) REFERENCES TipoOrdemServicos (TipoOrdemServicoId),
FOREIGN KEY(UsuarioId) REFERENCES Usuarios (UsuarioId)
)

ALTER TABLE ProdutosOrdens ADD FOREIGN KEY(OrdemServicoId) REFERENCES OrdemServicos (OrdemServicoId)
ALTER TABLE ProdutosOrdens ADD FOREIGN KEY(ProdutoId) REFERENCES Produtos (ProdutoId)
ALTER TABLE UsuarioPermissoes ADD FOREIGN KEY(TipoUsuarioId) REFERENCES TipoUsuarios (TipoUsuarioId)
ALTER TABLE LogOrdens ADD FOREIGN KEY(OrdemServicoId) REFERENCES OrdemServicos (OrdemServicoId)
ALTER TABLE CompraProdutos ADD FOREIGN KEY(CompraId) REFERENCES Compras (CompraId)
ALTER TABLE CompraProdutos ADD FOREIGN KEY(ProdutoId) REFERENCES Produtos (ProdutoId)
ALTER TABLE Compras ADD FOREIGN KEY(FornecedorId) REFERENCES Fornecedores (FornecedorId)
ALTER TABLE Produtos ADD FOREIGN KEY(PrateleiraId) REFERENCES Prateleiras (PrateleiraId)
ALTER TABLE Prateleiras ADD FOREIGN KEY(CategoriaId) REFERENCES Categorias (CategoriaId)
ALTER TABLE Categorias ADD FOREIGN KEY(TipoProdutoId) REFERENCES TipoProdutos (TipoProdutoId)
