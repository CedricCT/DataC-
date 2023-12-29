Analyse de Données de Restauration en C#
========================================

Description
-----------

Ce projet C# permet de charger, analyser et exporter des données de restauration. Il lit des fichiers CSV correspondant aux mois de l'année 2017, regroupe les données, effectue des calculs analytiques et exporte les résultats. Les analyses incluent le calcul du nombre total de clients par jour et par mois.

Prérequis
---------

Pour exécuter ce programme, assurez-vous d'avoir installé :

*   .NET Core 3.1 SDK ou une version ultérieure
*   CsvHelper package (peut être installé via NuGet)

Installation
------------

1.  Clonez le dépôt ou téléchargez les fichiers sources.
2.  Ouvrez le dossier du projet dans votre IDE ou éditeur de code préféré.

Installation des Dépendances
----------------------------

Utilisez NuGet pour installer les dépendances nécessaires :

shellCopy code

`dotnet add package CsvHelper`

Structure des Données
---------------------

Les données doivent être structurées en fichiers CSV avec les colonnes suivantes : Date, Service, nbTable, nbCustomer, TotalPrice. Les fichiers doivent être placés dans un dossier `/data/2017` à la racine du projet.

Exécution du Programme
----------------------

Pour exécuter le programme, utilisez la commande suivante depuis la racine du projet :

shellCopy code

`dotnet run`

Résultats
---------

Le programme exporte deux fichiers CSV :

*   `customersPerDay.csv` : Nombre total de clients par jour.
*   `customersPerMonth.csv` : Nombre total de clients par mois.

Ces fichiers seront sauvegardés dans le même dossier que l'exécutable du projet.