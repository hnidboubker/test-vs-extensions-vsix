# AI_CONTEXT.md

**Project**: ToolWindowVSIXPR | **Type**: Visual Studio Extension (VSIX)  
**Date Updated**: 2026-09-04 | **Status**: Stable

---

## 🎯 Qu'est-ce que ce projet?

Extension Visual Studio 2022 qui ajoute une **fenêtre d'outils personnalisée** accessible via menu.

## 🛠️ Stack technologique

- **Langage**: C# (.NET Framework 4.8)
- **IDE**: Visual Studio 2022 (v17.x)
- **Build**: MSBuild
- **Framework**: Community.VisualStudio.Toolkit
- **UI**: WPF + XAML

## 🏗️ Architecture générale

```
ToolWindowVSIXPR (Extension Package)
├── Package Entry Point (ToolWindowVSIXPRPackage.cs)
├── Commands (MyToolWindowCommand.cs) → Shows tool window
├── Tool Windows (MyToolWindow.cs) → Container
└── UI Layer (MyToolWindowControl.xaml) → WPF interface
```

## 📦 Composants clés

| Composant | Rôle |
|-----------|------|
| `ToolWindowVSIXPRPackage.cs` | Point d'entrée, initialise extension |
| `MyToolWindowCommand.cs` | Gestionnaire du menu/commande |
| `MyToolWindow.cs` | Conteneur de la fenêtre d'outils |
| `MyToolWindowControl.xaml` | Interface WPF |
| `VSCommandTable.vsct` | Définitions des commandes/menus |

## ⚙️ Comment ça fonctionne

1. **Startup**: Extension se charge dans VS2022 experimental hive
2. **User Action**: Utilisateur clique sur le menu (ou raccourci clavier)
3. **Command Execution**: `MyToolWindowCommand` s'exécute
4. **Tool Window Display**: `MyToolWindow` crée l'UI et affiche la fenêtre
5. **Debugging**: Breakpoints travaillent directement dans VS principal

## 🎯 État actuel

- ✅ Architecture de base stable
- ✅ Fenêtre d'outils fonctionne
- ✅ Theming (dark/light mode) supporté
- ⚠️ Pas de tests unitaires (à ajouter)
- ⚠️ Fonctionnalités minimales

## 🚫 Contraintes importantes

- **VS 17.0+ uniquement** - pas de support versions anciennes
- **Framework 4.8 obligatoire** - ne pas updater lightly
- **Experimental hive** - ne pollue pas l'installation principale
- **VSIX output** - à `bin/Debug/ToolWindowVSIXPR.vsix`
- **Respect VSIX manifest** - versions et dépendances strictes

## 🎮 Commandes essentielles

```bash
# Build Debug
MSBuild tools-tests\tools-tests.sln /p:Configuration=Debug

# Run avec F5 (depuis VS) = lance VS experimental avec extension

# Clean
MSBuild tools-tests\tools-tests.sln /t:Clean
```

## 📝 Notes importantes

- Les fichiers `.vsct` et `.vsixmanifest` sont compilés → changements nécessitent rebuild
- Les `GUID` de commandes doivent être uniques
- WPF XAML compilation = changements UI nécessitent rebuild
- Community Toolkit gère le theming automatiquement

## 🔗 Fichiers essentiels à lire

Pour comprendre ce projet rapidement, lis:
1. `CLAUDE.md` - Règles du projet
2. `PROJECT_INDEX.md` - Quoi lire pour quelle tâche
3. `.agents/05_ARCHITECTURE.md` - Architecture détaillée
4. `PROJECT_MEMORY.md` - Historique et leçons

---

**Généré automatiquement** | Maintenu par: Houssine + Claude
