# PROJECT_INDEX.md

**Navigation guide** - Quels fichiers lire selon ta tâche

---

## 🚀 Avant de commencer

**TOUJOURS lire en premier:**
1. `CLAUDE.md` - Règles et comportement attendu
2. `AI_CONTEXT.md` - Résumé du projet (2 minutes)
3. Ce fichier (PROJECT_INDEX.md) - Où aller selon ta tâche

---

## 📋 Par type de tâche

### 🐛 Je dois corriger un bug

**Lis dans cet ordre:**
1. `.agents/01_RULES.md` - Règles strictes
2. `AI_CONTEXT.md` - Contexte rapide
3. `.agents/03_CHECKLIST_BEFORE_COMMIT.md` - Checklist avant commit
4. `.agents/05_ARCHITECTURE.md` - Architecture si tu dois modifier le core
5. `PROJECT_MEMORY.md` - Historique des bugs passés

**Outils spécialisés:**
- Skill `issue-resolution` - Diagnostic et résolution auto
- Skill `auto-issue-on-bug-detection` - Créer issue GitHub

---

### ✨ Je dois ajouter une feature

**Lis dans cet ordre:**
1. `.agents/01_RULES.md` - Règles
2. `AI_CONTEXT.md` - Contexte
3. `.agents/05_ARCHITECTURE.md` - Architecture (important!)
4. `.agents/04_LANGUAGE_SPECIFIC.md` - Patterns C#/VSIX
5. `.agents/06_SKILLS_AVAILABLE.md` - Skills disponibles
6. `CLAUDE.md` - Point architecture spécifique si besoin

**Exemple workflow:**
- Lire architecture complète
- Comprendre où insérer la feature
- Respecter patterns existants
- Tester dans VS experimental

---

### 🔍 Je dois faire une code review

**Lis dans cet ordre:**
1. `.agents/07_AUDIT_REQUIREMENTS.md` - Critères d'audit
2. `.agents/03_CHECKLIST_BEFORE_COMMIT.md` - Checklist qualité
3. `.agents/04_LANGUAGE_SPECIFIC.md` - Standards C#
4. `AI_CONTEXT.md` - Contexte rapide du changement
5. `.agents/05_ARCHITECTURE.md` - Si changement architectural

**Focus sur:**
- Respect des règles
- Patterns VSIX/WPF
- Performance et sécurité
- Tests et validation

---

### 📚 Je veux comprendre l'architecture

**Lis dans cet ordre:**
1. `AI_CONTEXT.md` - Vue d'ensemble (5 min)
2. `.agents/05_ARCHITECTURE.md` - Architecture détaillée (30 min)
3. `.agents/04_LANGUAGE_SPECIFIC.md` - Patterns spécifiques (20 min)
4. `CLAUDE.md` - Patterns du projet (10 min)
5. Ensuite: code source directement

---

### 🧪 Je dois écrire ou exécuter des tests

**Lis dans cet ordre:**
1. `.agents/04_LANGUAGE_SPECIFIC.md` - Section "Tests"
2. `.agents/07_AUDIT_REQUIREMENTS.md` - Critères de test
3. `PROJECT_MEMORY.md` - Historique des tests

**Note:** Le projet n'a pas de tests unitaires pour l'instant (TODO)

---

### 🔧 Je dois mettre à jour la configuration

**Pour MCP/GitHub:**
- `.agents/09_MCP_GITHUB_CONFIG.md` - Configuration MCP

**Pour Settings/Permissions:**
- `.agents/01_RULES.md` - Règles de permissions
- `~/.claude/settings.json` - Permissions globales

**Pour VSIX Manifest:**
- `CLAUDE.md` - Section "Update Extension Metadata"

---

### 🎯 Je dois faire une première lecture

**Ordre recommandé (1 heure):**
1. `CLAUDE.md` (5 min) - Règles globales
2. `AI_CONTEXT.md` (10 min) - Résumé du projet
3. `.agents/00_START_HERE.md` (10 min) - Bienvenue
4. `.agents/05_ARCHITECTURE.md` (20 min) - Architecture
5. `.agents/04_LANGUAGE_SPECIFIC.md` (15 min) - Patterns

---

## 📂 Référence rapide des fichiers

| Fichier | Contenu |
|---------|---------|
| **CLAUDE.md** | Règles, setup, architecture générale |
| **AI_CONTEXT.md** | Résumé rapide du projet (2 min) |
| **PROJECT_INDEX.md** | Ce fichier - navigation |
| **PROJECT_MEMORY.md** | Historique, décisions, leçons |
| **.agents/00_START_HERE.md** | Bienvenue et ordre de lecture |
| **.agents/01_RULES.md** | Règles strictes du projet |
| **.agents/02_QUESTION_PROTOCOL.md** | Comment poser les bonnes questions |
| **.agents/03_CHECKLIST_BEFORE_COMMIT.md** | Checklist pré-commit |
| **.agents/04_LANGUAGE_SPECIFIC.md** | Patterns C#/VSIX |
| **.agents/05_ARCHITECTURE.md** | Architecture détaillée |
| **.agents/06_SKILLS_AVAILABLE.md** | Skills et compétences |
| **.agents/07_AUDIT_REQUIREMENTS.md** | Exigences d'audit |
| **.agents/08_AUTO_ISSUE_SKILL.md** | Auto-création d'issues |
| **.agents/09_MCP_GITHUB_CONFIG.md** | Config MCP GitHub |
| **.agents/10_COMPLETE_WORKFLOW.md** | Workflow complet |
| **.skills/** | Custom skills du projet |

---

## 🎯 Règle d'or

> **Avant de faire un changement:**  
> 1. Identifie le TYPE de tâche (bug, feature, review, etc.)
> 2. Lis la section correspondante ci-dessus
> 3. Suis l'ordre recommandé
> 4. Lis les fichiers une fois complètement
> 5. Puis agis

**Ne lis pas TOUT à chaque fois** - lis ce qui est pertinent pour TA tâche.

---

**Maintenu par**: Houssine + Claude  
**Mis à jour**: 2026-09-04
