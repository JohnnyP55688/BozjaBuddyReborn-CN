# Bozja Buddy Reborn 国服版

适用于 Dalamud API 15 的博兹雅南方战线 / 扎杜诺尔流程插件，提供遭遇战与临界战斗追踪、移动编排、义军武器素材进度、失传技能组和多角色辅助功能。

本仓库是国服兼容构建，使用独立内部名称 `BozjaBuddyRebornCN`，避免被卫月与上游同名插件判定为重复而禁用。

## 代码来源与致谢

- 上游项目：[OmegaJackie/DalamudPlugins](https://github.com/OmegaJackie/DalamudPlugins) 中的 `BozjaBuddyReborn`。
- ECommons：[NightmareXIV/ECommons](https://github.com/NightmareXIV/ECommons)。
- 本仓库保留上游许可证与第三方声明；国服版的修改不代表上游作者提供支持。
- FINAL FANTASY XIV 及相关名称归 SQUARE ENIX 所有。本项目与 SQUARE ENIX、XIVLauncher 和 Dalamud 官方无隶属关系。

## 国服版修改

### 1.0.29.0

- 将程序集和卫月内部名称改为 `BozjaBuddyRebornCN`，解决上游同名记录导致开发版插件被自动禁用的问题。
- 更新中文名称、仓库地址和来源说明。
- 使用国服 XIVLauncherCN 的 Dalamud API 15 开发库完成 Release 编译验证。

## 依赖

- Dalamud API 15
- vnavmesh
- Lifestream
- BossMod 或 BossMod Reborn
- Rotation Solver Reborn（需要自动战斗时）
- ECommons（已包含在发布包中）

不要同时启动 BBR 与普通 FATE 自动化插件，两者会争夺移动和战斗控制。

## 安装

### 卫月在线仓库

在卫月设置的“自定义插件仓库”中添加：

```text
https://raw.githubusercontent.com/JohnnyP55688/BozjaBuddyReborn-CN/main/repo.json
```

随后在插件安装器中搜索“Bozja Buddy Reborn 国服版”。在仓库首次发布 Release 前，此地址不会提供有效下载。

### 本地开发版

把 `release` 文件夹中的所有文件放在同一目录，再在卫月开发者设置中选择 `BozjaBuddyRebornCN.dll`。

## 常用命令

- `/bbr`：打开主窗口。
- `/bbr config`：打开设置。
- `/bbr relic` 或 `/bbrelic`：打开义军武器进度。
- `/bbr stop`：立即停止自动流程。

## 构建

需要 .NET 10 SDK 和当前 Dalamud API 15 开发库：

```powershell
git submodule update --init --recursive
$env:DALAMUD_HOME = "$env:APPDATA\XIVLauncherCN\addon\Hooks\dev"
dotnet build BozjaBuddyReborn.csproj -c Release -p:DalamudLibPath="$env:DALAMUD_HOME\"
```

已验证范围仅包括源码编译。游戏内加载、博兹雅内移动、临界战斗报名和完整自动循环仍需要分别实测。

## 风险提示

Dalamud 插件属于非官方第三方工具。自动化功能可能违反游戏服务条款并导致账号处罚，请自行判断并承担风险。不要无人值守运行。
