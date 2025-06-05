# 🎓 Mini-Projet - Module 110 : Gestion de Notes avec Monitoring

## 📌 Objectif
Créer une application **Windows Forms en C#** permettant de gérer des élèves, des cours, et des notes pondérées, tout en exposant des métriques à **Prometheus** pour les visualiser dans **Grafana**.

---

## 🛠 Fonctionnalités principales
- Ajout d’élèves et de cours
- Ajout de notes avec pondération (x1 à x5)
- Calcul automatique des moyennes pondérées par élève et cours
- Stockage dans une base de données **MariaDB**
- Exposition de métriques sur un **serveur HTTP Prometheus (port 1234)**
- Visualisation en temps réel via **Grafana (port 3000)**
- Définition d’alertes en cas de seuil critique (ex : moyenne < 10)

---

## ⚙️ Technologies utilisées
- C# .NET 6 (Windows Forms)
- [`prometheus-net.AspNetCore`](https://github.com/prometheus-net/prometheus-net)
- MariaDB avec `MySql.Data`
- Prometheus (`http://localhost:9090`)
- Grafana (`http://localhost:3000`)

---

## 📁 Fichiers fournis
| Nom du fichier                  | Rôle                                         |
|--------------------------------|----------------------------------------------|
| `GestionNotesWinForms/`                       | Application Windows Forms complète           |
| `gestion_note.sql`                            | Script SQL de création de la base            |
| `prometheus.yml`                              | Configuration Prometheus (port 1234)         |
| `dashboard_gestion_notes.json`                | Dashboard Grafana prêt à importer            |
| `Documentation_Projet.docx`                   | Rapport du projet                            |
| `Presentation_Mini_Projet_Monitoring.pptx`    | Presentation slide du projet                 |
| `README.md`                                   | Instructions de déploiement                  |

---

## 🧪 Lancer le projet étape par étape

1. **Importer la base** avec `create_db.sql` et `insert_data.sql` dans **MariaDB**
2. **Lancer Prometheus** avec :
   ```bash
   prometheus --config.file=prometheus.yml
   ```
   Il accèdera à l’app via `http://localhost:1234/metrics`
3. **Lancer l’application Windows Forms**
4. **Ouvrir Grafana** sur [http://localhost:3000](http://localhost:3000)
5. Ajouter la source Prometheus (`http://localhost:9090`)
6. **Importer le fichier JSON** de dashboard fourni
7. Visualiser les métriques et configurer des alertes

---

## 📊 Métriques exposées par l'application
- `eleve_count` → Nombre total d’élèves
- `cours_count` → Nombre total de cours
- `note_count` → Nombre total de notes
- `moyenne_globale_ponderee` → Moyenne pondérée globale
- `error_count` → Nombre d’erreurs système (ex. : échec BDD)

---

## 📌 Idées d’améliorations
- Ajouter des **filtres temporels** dans le dashboard Grafana
- Ajouter un export PDF/Excel des résultats
- Enregistrer les logs d’événements dans un fichier
- Ajouter des autorisations par rôle (admin/utilisateur)
