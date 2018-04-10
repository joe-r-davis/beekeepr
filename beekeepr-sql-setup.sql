-- CREATE TABLE users (
--     id VARCHAR(255) NOT NULL,
--     username VARCHAR(20) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     password VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     UNIQUE KEY email (email)
-- );

-- CREATE TABLE vaults (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(30) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     title VARCHAR(20) NOT NULL,
--     imageUrl VARCHAR(255) NOT NULL,
--     articleUrl VARCHAR(255) NOT NULL,
--     public TINYINT,
--     keepCount INT,
--     shareCount INT,
--     viewCount INT,
--     userId VARCHAR(255),
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--       REFERENCES users(id)
--       ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE vaultkeeps (
--     id int NOT NULL AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (vaultId, keepId),
--     INDEX (userId),

--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (keepId)
--         REFERENCES keeps(id)
--         ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = 2)

-- DROP TABLE users;

-- INSERT INTO keeps(
-- title,
-- imageUrl,
-- articleUrl,
-- public,
-- keepCount,
-- shareCount,
-- viewCount,
-- userId
-- ) VALUES (
-- "Pinehurst Kids photo",
-- "https://f4.bcbits.com/img/a3319694587_16.jpg",
-- "https://pinehurstkids.bandcamp.com/",
-- "1",
-- "0",
-- "0",
-- "0",
-- "d8ae9aef-6f3c-41f0-912d-58580501dd5c"
-- );

-- INSERT INTO vaults(
-- name,
-- description,
-- userId
-- ) VALUES (
-- "Pinehurst Kids photos",
-- "Band photos throughout the years",
-- "d8ae9aef-6f3c-41f0-912d-58580501dd5c"
-- );

-- INSERT INTO vaults(
-- name,
-- description,
-- userId
-- ) VALUES (
-- "Delete this Vault",
-- "update me and then delete me",
-- "d8ae9aef-6f3c-41f0-912d-58580501dd5c"
-- );