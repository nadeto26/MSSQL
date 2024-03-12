﻿USE [Accounting]
GO

--- Table: Countries
SET IDENTITY_INSERT Countries ON
INSERT INTO Countries (Id, [Name]) VALUES
(1, 'Austria'),
(2, 'France'),
(3, 'Germany'),
(4, 'Italy'),
(5, 'Spain'),
(6, 'Sweden'),
(7, 'Greece'),
(8, 'Romania'),
(9, 'Slovakia')
SET IDENTITY_INSERT Countries OFF