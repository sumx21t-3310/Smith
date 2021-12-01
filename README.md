# Shooter Weapon System For Unity

FPS/TPSの武器をノーコードで武器を作成できるフレームワーク

# 特徴
**Weapon System for Unity**はFPS/TPS向けのあらゆる武器をノーコードで作成可能なフレームワークです。 Riot
Gamesの[Valorant](https://playvalorant.com/en-us/arsenal/) に登場する武器を参考に作成されました。
* 一般的な武器であれば、インスペクターで完結。ノーコードで武器が作成できます。
* 各種インターフェース、基底クラスを実装するだけで動作を拡張することができます。
* EffectやBuiltin Audioに非依存。再生タイミングはUnityEventで表現。
* ProjectileとHitScanを選択可能。
* 弾丸の発射位置を変更可能。
* マガジンの種類を変更可能。
* 銃弾の保管方法を変更可能。

## 実装済みアクション

### Attack

- ShootingAction
- ShotgunShootingAction

### Aim

- AimAction
- ScopeAimAction
- ZoomOnlyAimAction

### Control

- AimSwitchingAction
- EventInvokeAction
- SelectableAction

## Interactable

- GrabAction

## Template

- IntervalActionBase

## 実装済みリコイル

- PatternRecoil
- SinRecoil
- NoneRecoil
- RandomRecoil
---
# Requirement

Weapon System では、以下の環境が必須になります。

- Unity 2020 LTS Later
- [mackysoft.Unity-SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions)

# Install



## `.unitypackage`を使う

- [Release](https://github.com/NebusokuDev/ShooterWeaponSystemForUnity/releases) から`.unitypackage`をダウンロードし、インストールします。

## git urlを使う

git urlを利用してインストールすることができます。 インストールする場合は、 パッケージマネージャの`Add package from git URL...`に以下のurlを入力してください。

#### URL: `https://github.com/NebusokuDev/ShooterWeaponSystemForUnity.git?path=Assets/NebusokuDev/ShooterWeaponSystem`

[使い方はこちらを参考にしてください](https://docs.unity3d.com/2019.4/Documentation/Manual/upm-ui-giturl.html)

## OpenUPMを使う

OpenUPMを利用してインストールすることができます。 OpenUPMレジストリを`Project Settings/Scoped Registry`に登録し、以下のパッケージを登録します。

#### `com.nebusoku-dev.shooter-weapon-system-for-unity`

もしくは、以下のコマンドラインをプロジェクトディレクトリ配下で入力します。

#### `openupm add com.nebusoku-dev.shooter-weapon-system-for-unity` 

# Usage

## ObjectPoolBinderの設定

WeaponSystemのObjectPoolは`Locator<T>`からファクトリメソッドを利用し、依存性を解決しています。 そのため、このフレームワークを利用するシーンでは、`ObjectPoolBinder`
をシーンに付与する必要があります。

1. 空のGameObjectを作成し、名前を`ObjectPoolBinder`とします。
2. `ObjectPoolBinder`を作成したGameObjectにアタッチします。

> 独自のObjectPoolを利用したい場合は`IObjectPoolFactory`を実装してください。

## プレイヤーの設定

### Moverのセッティング

テスト用のFPS/TPS向けのキャラクターコントローラーが用意されています。

### 当たり判定の設定

1. プレイヤーのルートに`HitPoint`, `ObjectGroup`をアタッチします。

> #### info
> 独自のHitPointを利用したい場合は`IHasHitPoint`を実装してください。

## 武器の設定

1. 空のGameObjectを作成し、任意の名前にします
2. 作成したGameObjectに`ObjectPermission`, `Weapon`, `LegacyWeaponInput`をアタッチします。
3. それぞれのアクションに対し、設定していきます。


- `[Serialize Reference]`アトリビュートを使用しているため拡張したクラスには、`[System.Serializable]`アトリビュートを必ず追加してください。
- インスペクターのGUIを展開するとフレームレートとが急激に下がります。実行する際には、インスペクターのGUIを閉じてから実行してください。

# Author

- NebusokuDev

# Contact

# License

"Shooter Weapon System For Unity" is under [MIT license](https://en.wikipedia.org/wiki/MIT_License).