<!-- 分かりやすくてカッコイイ名前をつける -->
# Shooter Weapon System for Unity

[comment]: <> ("Weapon System"が何かを簡潔に紹介する)
Weapon SystemはFPS/TPS向けのあらゆる武器を作成可能なフレームワークです。
Riot Gamesの[Valorant](https://playvalorant.com/en-us/arsenal/) に登場する武器を参考に作成されました。

# Futures
* 一般的な武器であれば、インスペクターで完結。ノーコードで武器が作成できます。 
* 各種インターフェース、基底クラスを実装するだけで動作を拡張することができます。
* EffectやBuiltin Audioに非依存。再生タイミングはUnityEventで表現。 
* ProjectileとHitScanを選択可能。
* 弾丸の発射位置を変更可能。
* マガジンの種類を変更可能。
* 銃弾の保管方法を変更可能。


<!-- インスペクターをいじってるgifをはる -->
## Implemented Weapon Actions
- Aim
  - Aim
  - Scope Aim
  - Zoom Only Aim
- Attack
  - Shooting
  - ShotgunShooting
- Control
  - Aim Switching
  - Selectable
  - EventInvoke
- Interact
  - Grab
- Template
  - Interval Action Base


# Requirement

<!-- "Weapon System"を動かすのに必要なライブラリなどを列挙する -->

* Unity 2019 LTS Later.
* [mackysoft - Unity-SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions)


# Usage
## Install
ディレクトリをそのままD&Dしてください。

## Setup
<!-- 各種インスペクターの画像を貼る -->
1. 空のゲームオブジェクトを作成します。
2. 空のゲームオブジェクトにSingleActionWeapon, DualActionWeapon, Generic Weaponのいずれかをアタッチします。
3. 各Weaponに適合するInputをアタッチします。
4. 武器の種類に合わせてアクション、マガジン、アモホルダーをセッティングします。
5. ShootingActionなど、ObjectPoolを使用する場合は空のゲームオブジェクトを作成し、ObjectPoolBinderをアタッチします。


### ObjectPoolBinderのセットアップ
1. 空のゲームオブジェクトを作成し、名前を`ObjectPoolBinder`をとします。
1. ObjectPoolBinderコンポーネントをアタッチします。
1. 

> 独自のObjectPoolを利用したい場合は`IObjectPoolFactory`を実装してください。

### Characterのセットアップ
> 独自のHitPointを利用したい場合は`IHasHitPoint`を実装してください。
### 武器のセットアップ
1. 



# Note
<!-- 注意点などがあれば書く -->
* Inspectorの表示を開いたまま再生すると顕著にフレームレートが落ちます。再生する場合はなるべく折りたたんでから再生するようにしてください。
* 自作したコードには必ず`System.Serializable`アトリビュートを付与してください。

# Contact
バグや改善点、要望、実装方法の質問などがあればIssuesへ登録お願いします。
プルリクエストもお待ちしております。


# License

<!-- ライセンスを明示する -->

"Shooter Weapon System for Unity" is under [MIT license](https://en.wikipedia.org/wiki/MIT_License).