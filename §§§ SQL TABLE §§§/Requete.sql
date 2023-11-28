--Drop TABLE clientBanque;
--Drop TABLE clientCompte;
--Drop TABLE compte;
--Drop TABLE operation;
/*
 * Création table Utilisateur
 */
--CREATE TABLE specialite
--(
--	[idSpecialite] INT IDENTITY (1, 1) NOT NULL, 
--    intituleSpecialite VARCHAR(50) NOT NULL, 
--    PRIMARY KEY CLUSTERED ([idSpecialite] ASC)
--)
--SELECT * FROM rdv 
--WHERE  (DATEPART(yy, dateRDV) = 1987
--AND    DATEPART(mm, dateRDV) = 03
--AND    DATEPART(dd, dateRDV) = 18)

--SELECT * FROM rdv
--WHERE CONVERT(VARCHAR(25), dateRDV, 126) LIKE '1987'
--SELECT 
--                m.codeMedecin
--                from medecin m

--CREATE TABLE client
--(
--	[id] INT IDENTITY (1, 1) NOT NULL, 
--    Nom VARCHAR(50) NOT NULL, 
--    Prenom VARCHAR(50) NOT NULL, 
--    Telephone VARCHAR(50) NOT NULL, 
--    PRIMARY KEY CLUSTERED (id ASC)
--)

--CREATE TABLE compte
--(
--	[id] INT IDENTITY (1, 1) NOT NULL, 
--    Numero VARCHAR(50) NOT NULL, 
--    Solde DECIMAL NOT NULL, 
--    Client_id INT NOT NULL, 
--    PRIMARY KEY CLUSTERED (id ASC)
--)

--CREATE TABLE operation
--(
--	[id] INT IDENTITY (1, 1) NOT NULL, 
--    compte_id INT NOT NULL, 
--    montant DECIMAL NOT NULL, 
--    PRIMARY KEY CLUSTERED (id ASC)
--)

--SELECT 
--                r.id, r.dateRDV, r.heureRDV, r.codeMedecin, r.codePatient, m.nomMedecin, m.specialiteMedecin, p.nomPatient, p.dateNaissance, p.sexePatient
--                 from rdv r inner join medecin m on r.codeMedecin=m.codeMedecin inner join patient p on r.codePatient=p.codePatient


--SELECT c.id, c.solde, cl.id, cl.Nom, cl.Prenom, cl.Telephone, c.Numero FROM compte as c inner join client as cl on c.client_id=cl.id




--CREATE TABLE patient
--(
--	[id] INT IDENTITY (1, 1) NOT NULL, 
--    codePatient VARCHAR(50) NOT NULL, 
--    nomPatient VARCHAR(50) NOT NULL, 
--    adressePatient VARCHAR(50) NOT NULL, 
--    dateNaissance DATETIME NOT NULL, 
--    sexePatient VARCHAR(50) NOT NULL, 
--    PRIMARY KEY CLUSTERED (id ASC)
--)

--CREATE TABLE rdv
--(
--	[id] INT IDENTITY (1, 1) NOT NULL, 
--    dateRDV DATETIME NOT NULL, 
--    heureRDV VARCHAR(50) NOT NULL, 
--    codeMedecin VARCHAR(50) NOT NULL, 
--    codePatient VARCHAR(50) NOT NULL, 
--    PRIMARY KEY CLUSTERED (id ASC)
--)

--SELECT
--                m.id, m.codeMedecin, m.nomMedecin, m.telMedecin, m.dateEmbauche, s.intituleSpecialite
--                 from medecin m left join specialite s on m.specialiteMedecin = s.idSpecialite 


--SELECT 
--                m.id, m.codeMedecin, m.nomMedecin, m.telMedecin, m.dateEmbauche, s.intituleSpecialite
--                 from medecin m left join specialite s on m.specialiteMedecin = s.id 


/*
 * Création table Compte
-- */
--CREATE TABLE [dbo].[compte]
--(
--	[Id] INT IDENTITY (1, 1) NOT NULL,
--    [numeroCompte]       VARCHAR (50)    NOT NULL,    
--    [solde]        DECIMAL (10, 2) NOT NULL,
--    [dateCreation] DATETIME        NOT NULL,
--    PRIMARY KEY CLUSTERED ([id] ASC)
--)
--/*
-- * Création table Clientcompte
-- */
--CREATE TABLE [dbo].[clientCompte]
--(
--	[Id] INT IDENTITY (1, 1) NOT NULL, 
--    [idClient]       VARCHAR (50)    NOT NULL,    
--    [idCompte]       VARCHAR (50)    NOT NULL,
--    PRIMARY KEY CLUSTERED ([id] ASC)
--)
--/*
-- * Création table opération
-- */
--CREATE TABLE [dbo].[operation]
--(
--	[Id] INT IDENTITY (1, 1) NOT NULL,
--    [idcompte]    VARCHAR (50) NOT NULL,
--    [dateOperation] DATETIME     NOT NULL,
--    [montant]      DECIMAL (18) NOT NULL,
--    PRIMARY KEY CLUSTERED ([id] ASC)
--)
