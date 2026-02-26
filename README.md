# NexaWorks - Système de Gestion des Tickets

## 📌 Présentation du projet
Ce projet consiste en la conception et la mise en œuvre d'une base de données relationnelle pour le support technique de l'entreprise **NexaWorks**. L'objectif est de centraliser les incidents signalés par les utilisateurs sur différents logiciels (produits) et environnements (systèmes d'exploitation) afin de faciliter le suivi et la résolution par l'équipe technique.

## 🗺️ Modèle Entité-Association (MCD)
Le schéma suivant illustre l'architecture de la base de données. Il met en évidence les relations entre les tickets, les produits, les versions logicielles et les systèmes d'exploitation.

<img width="1117" height="650" alt="MEA" src="https://github.com/user-attachments/assets/8112ad54-ff9c-4878-ab0d-059813cc840a" />

> **Note :** Les relations utilisent des clés étrangères pour garantir l'intégrité des données entre les tables `Ticket`, `Produit`, `Version` et `SystemeExploitation`.
