
DELETE FABRICANTE_CONTENT

DELETE FABRICANTE
DBCC CHECKIDENT('FABRICANTE',RESEED, 0)

DELETE APRESENTACAO_CONTENT


DELETE APRESENTACAOMATERIAL
DBCC CHECKIDENT('APRESENTACAOMATERIAL',RESEED, 0)

DELETE CONTENT_MATERIAL
DBCC CHECKIDENT('CONTENT_MATERIAL',RESEED, 0)

DELETE MATERIAL 
DBCC CHECKIDENT('MATERIAL',RESEED, 0)

DELETE EMPRESA 
DBCC CHECKIDENT('EMPRESA',RESEED, 0)

DELETE CLASSE_RISCO 
DBCC CHECKIDENT('CLASSE_RISCO',RESEED, 0)

DELETE MENSAGEM 
DBCC CHECKIDENT('MENSAGEM',RESEED, 0)

DELETE VENCIMENTO 
DBCC CHECKIDENT('VENCIMENTO',RESEED, 0)





