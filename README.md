# Shooter Weapon System For Unity

FPS/TPSの武器をノーコードで武器を作成できるフレームワーク

# 特徴
**Weapon System for Unity** はFPS/TPSの武器を作成するためのフレームワークです。
以下の特徴を持ちます。
- ノーコード
- 音声、エフェクトのタイミングはUnityEventで表現、
- 右クリック、左クリックの
- 
# Requirement

- Unity 2020 LTS
- [mackysoft.Unity-SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions)

# Install

## .unitypackageを使う

1. [mackysoft.Unity-SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions)
   をインストールします。
2. [Release](https://github.com/NebusokuDev/ShooterWeaponSystemForUnity/releases) から`.unitypackage`をダウンロードし、インストールします。

## git urlを使う

パッケージマネージャの`Add package from git URL...`に以下のurlを入力してください。

#### URL: `https://github.com/NebusokuDev/ShooterWeaponSystemForUnity.git?path=Assets/NebusokuDev/ShooterWeaponSystem`

[使い方はこちらを参考にしてください](https://docs.unity3d.com/2019.4/Documentation/Manual/upm-ui-giturl.html)

## OpenUPMを使う

Open UPMを利用してインストールすることができます。 OpenUPMレジストリを`Project Settings/Scoped Registry`に登録し、以下のパッケージを登録します。

#### URL: `com.nebusoku-dev.shooter-weapon-system-for-unity`

# Usage

## ObjectPoolBinderの設定
WeaponSystemのObjectPoolは`Locator<T>`からファクトリメソッドを利用し、依存性を解決しています。
そのため、このフレームワークを利用するシーンでは、`ObjectPoolBinder`をシーンに付与する必要があります。

1. 空のGameObjectを作成し、名前を`ObjectPoolBinder`とします。
2. `ObjectPoolBinder`を作成したGameObjectにアタッチします。

## Playerの設定
### 当たり判定の設定
## 武器の設定

### プロジェクタイル方式を採用する場合

# Note

- `[Serialize Reference]`アトリビュートを使用しているため拡張したクラスには、`[System.Serializable]`アトリビュートを必ず追加してください。
- インスペクターのGUIを展開するとフレームレートとが急激に下がります。実行する際には、インスペクターのGUIを閉じてから実行してください。
