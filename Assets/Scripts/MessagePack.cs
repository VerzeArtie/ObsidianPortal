using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ObsidianPortal
{
    public static class MessagePack
    {
        #region "アクションイベント"
        public enum ActionEvent
        {
            None,
            ObjectiveAdd,
            ObjectiveRemove,
            ObjectiveRefreshCheck,
            UpdateLocationTop,
            UpdateLocationLeft,
            UpdateLocationRight,
            UpdateLocationBottom,
            HomeTown,
            TurnToBlack,
            TurnToWhite,
            ReturnToNormal,
            MoveTop,
            MoveLeft,
            MoveRight,
            MoveBottom,
            BlueOpenTop,
            BlueOpenLeft,
            BlueOpenRight,
            BlueOpenBottom,
            TutorialOpen1,
            BigEntranceOpen,
            CenterBlueOpen,
            SmallEntranceOpen1,
            SmallEntranceOpen2,
            Floor2CenterOpen,
            UpdateUnknownTile,
            EncountBoss,
            StopMusic,
            PlayMusic01,
            PlaySound,
            YesNoGotoDungeon,
            YesNoBacktoDungeon,
            GoBackTutorial,
            GotoHomeTown,
            GotoHomeTownForce,
            DecisionOpenDoor1,
            HomeTownGetItemFullCheck,
            HomeTownRemoveItem,
            HomeTownBlackOut,
            HomeTownTurnToNormal,
            HomeTownBackToTown,
            HomeTownButtonVisibleControl,
            HomeTownMorning,
            HomeTownNight,
            HomeTownDuelSelect,
            HomeTownShowDuelRule,
            HomeTownFazilCastle,
            HomeTownFazilCastleMenu,
            HomeTownTicketChoice,
            HomeTownGoToKahlhanz,
            HomeTownGotoFirstPlace,
            HomeTownExecRestInn,
            HomeTownExecItemBank,
            HomeTownCallRequestFood,
            HomeTownButtonHidden,
            HomeTownMessageDisplay,
            HomeTownRewardDisplay,
            HomeTownYesNoMessageDisplay,
            HomeTownShowActiveSkillSpell,
            HomeTownShowActiveSkillSpellSC,
            HomeTownCallPotionShop,
            HomeTownCallSaveLoad,
            HomeTownCallDuel,
            HomeTownCallDecision,
            HomeTownCallDecision3,
            HomeTownAddNewCharacter,
            GetGreenPotionForLana,
            CallSomeMessageWithAnimation,
            CallSomeMessageWithNotJoinLana,
            DungeonBadEnd,
            DungeonGetTreasure,
            DungeonUpdateFieldElement,
            Floor2DownstairGateOpen,
            DungeonJumpToLocation1,
            DungeonMirrorRoomGodSequence,
            DungeonJumpToLocationRecollection4,
            DungeonSetupPlayerStatus,
            DungeonRemovePartyTC,
            RealWorldCallItemBank,
            AutoSaveWorldEnvironment,
            AutoMove,
            DungeonGotoDownstair,
            MirrorWay,
            MirrorLastWay,
            DungeonGotoDownstairFourTwo,
            JumpToLocationHellMirror1,
            UpdateUnknownTileAreaHellLast,
            DungeonGotoDownStairFiveTwo,
            UpdateUnknownTileAreaTruthFinal,
            Ending,
        }
        #endregion

        #region "アンシェットの街"
        public static void Message100010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message100010 = true;

            Message(ref m_list, ref e_list, "アイン：っしゃ・・・これで準備OKかな。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：え、ちょっとそれだけしか持っていかないワケ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：旅に出るんだ。荷物はこれぐらい軽くしておいたほうが良いだろ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：旅に出るわけじゃなくて、正式な調査依頼を受けて、任務遂行しに行くのよ。ちゃんと準備してよね、ホント。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：大丈夫だって、オーケーオーケー！ッハッハッハ！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：頭痛がしてきたわ・・・まったく・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：ところで、ちゃんと国外遠征許可証はそのバックパックに入ってるんでしょうね？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：国外・・・遠征・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：許可証だと？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：許可証を受け取りに、ファージル宮殿には行った？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：行ってねえな。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：許可証を受領するための期限が先週までだったのは知ってるわよね？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ウソだろ？そんな期限なんてあったか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：国外遠征許可証の推薦状にはちゃんと目を通したわけ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ、もちろんだ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：その推薦状に書いてあったわよ。ちゃんと見てないわよね？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ、もちろんだ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "『ッシャゴオォォオォォ！！！』（ラナのファイナリティ・ブローがアインに炸裂）", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：わ、分かった分かった・・・すまねえ。今から取ってくるからさ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：本当に行くんでしょうね？今日中に出発したいんだから、頼むわよホント。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ、任せとけ！ッハッハッハ！", ActionEvent.None);

            Message(ref m_list, ref e_list, "", ActionEvent.AutoSaveWorldEnvironment);

            Message(ref m_list, ref e_list, "", ActionEvent.None);
           
        }

        public static void Message100020(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message100020 = true;

            Message(ref m_list, ref e_list, "アイン：よし、" + FIX.TOWN_FAZIL_CASTLE + "に到着。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：正面ゲートから入ったらすぐ横の受付を済ませてちょうだいね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ、わかった。了解了解！", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：って、おわぁ！！　なんで横に居るんだよ！？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：バカアインが迷子になるのは目に見えてるからよ。しょーがないから来てあげたんじゃない。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ま・・・まあ、正直なところ宮殿はほぼ歩いた事がねえ・・・助かるけどな。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：ホラ、そこの受付に早く行って頂戴。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ、わかった。", ActionEvent.None);

            Message(ref m_list, ref e_list, "～" + FIX.TOWN_FAZIL_CASTLE + "、受付口にて ～", ActionEvent.HomeTownMessageDisplay);

            Message(ref m_list, ref e_list, "　　【受付嬢：" + FIX.TOWN_FAZIL_CASTLE + "へようこそ。】", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：すまないがちょっと教えてくれ。国外遠征のための通行証が欲しいんだが。", ActionEvent.None);

            Message(ref m_list, ref e_list, "　　【受付嬢：ファージル王国からの推薦状をご提示願いますでしょうか。】", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：えっ！なんだって！？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：何言ってんのよ。さっき話してた用紙の事よ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ。あの紙の事か。それならここに持ってるぜ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "　　【受付嬢：推薦状を拝見いたします。しばらくお待ち下さい。】", ActionEvent.None);

            Message(ref m_list, ref e_list, "　　【受付嬢：・・・　・・・】", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：・・・　・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "　　【受付嬢：アイン・ウォーレンス様ですね。本日はようこそおいでくださいました。】", ActionEvent.None);

            Message(ref m_list, ref e_list, "　　【受付嬢：こちらがアイン・ウォーレンス様の国外遠征許可証となります。】", ActionEvent.None);

            Message(ref m_list, ref e_list, "　　【受付嬢：どうぞ、お受け取りください。】", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：サンキュー！助かるぜ！", ActionEvent.None);

            Message(ref m_list, ref e_list, "　　【受付嬢：なお、エルミ・ジョルジュ国王陛下よりアイン・ウォーレンス様へ連絡があるとの事です。】", ActionEvent.None);

            Message(ref m_list, ref e_list, "　　【受付嬢：本日、この国外遠征許可証をお持ちの上、必ず謁見の間へ行かれます様、よろしくお願い申し上げます。】", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：エルミ国王が・・・なんだろう。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：バカアインが許可証もらうのをサボってたから、心配してるんじゃないの？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ハハハ・・・言われてみりゃそうかもな・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：謁見の間は宮殿の中央から３階まで上がった場所にあるわよ。早く行きましょう。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：了解！", ActionEvent.None);

            Message(ref m_list, ref e_list, "", ActionEvent.None);
           
        }
        public static void Message100030(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message100030 = true;

            Message(ref m_list, ref e_list, "アイン：よし、謁見の間は確かここだったな。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：じゃ、行ってきてちょうだい。失礼の無いようにね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：あれ、ラナは入らないのかよ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：呼ばれたのはアインだけよ。私が入る事はできないわ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：そうなのか。じゃあ俺一人で行ってくるぜ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "～ " + FIX.TOWN_FAZIL_CASTLE + "、謁見の間にて ～", ActionEvent.HomeTownMessageDisplay);

            Message(ref m_list, ref e_list, "アイン：し、失礼つかまつります！", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：アイン君だね。ようこそファージル宮殿へ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：この度は、ご機嫌うるわしく・・・候・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：難しい言葉は使わなくて良いよ。謁見の間では気楽に喋ってもらえれば良いから。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：は、はい。", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：ここに呼び出してしまって、すまなかったね。でも、どうしても一件頼みたい事があるんだ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：頼みたい事？", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：国外遠征先のヴィンスガルデ王国エリアで調査して欲しい案件があるんだ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：案件の内容は王妃ファラから解説させようと思う。", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：こら、ファラ。変なところに隠れてないで、ちゃんと出てきてくれ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：フフフ。ジャーン（＾＾", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ファ、ファラ様！お、お久しゅうございます。", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：ファラ。謁見の間でかくれんぼして遊んじゃいけないって言っただろ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：エルミのケチンボ（＾＾＃", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：ッグ・・・ケチで言ってるわけじゃない。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ハ、ハハ・・・ええと・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：アインさん、リラックスして聞いてくださいね（＾＾", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ハイ。分かりました。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：ファージル王国では、昔から古代アーティファクトにまつわる件を分析の対象としているの。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：古代アーティファクト？　そんなのがあるんですか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：伝説、古文書、語り継がれている伝承、そういったものは沢山あるのですが。", ActionEvent.None);
            
            Message(ref m_list, ref e_list, "アイン：信憑性の高いものはほとんど無い・・・って所ですかね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：ええ、その通りです。", ActionEvent.None);

            Message(ref m_list, ref e_list, "（　王妃ファラは少し真剣な眼差しを向けてきた　）", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：ヴィンスガルデ王国の歴史には一つの伝承があります。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：えっ・・・？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：その伝承には一つのキーワードが示されています。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：その名は【ObisidianStone】", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：Obisidian・・・Stone・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：アインさんには、そのObsidianStoneの調査を秘密裏に遂行していただきたいの。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：秘密裏・・・え。どういう事ですか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：ファラ、そこまでで良いよ。後はボクが話すから。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ファラ：あら、じゃあお願いしても良いかしら（＾＾", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：アイン君。ヴィンスガルデ王国に行くため、まずは" + FIX.TOWN_COTUHSYE + "へ寄って欲しい。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：" + FIX.TOWN_COTUHSYE + "？", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：ああ、沿岸沿いにある小さな港町だよ。そこから船を使ってヴィンスガルデ王国へ向かって欲しい。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：分かりました。じゃあ、まずは" + FIX.TOWN_COTUHSYE + "へ行ってみます。", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：港町までは少し距離がある。途中にある" + FIX.TOWN_QVELTA_TOWN + "に立ち寄るのも良いだろう。よろしく頼んだよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：えっと・・・到着したら何かやる事はありますか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：いや、特に何かっていうのは気にしなくて良いよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：天の導きがあれば、自然と道は拓かれる。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：そ、そんなもんですかね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "エルミ：アイン君ならきっと大丈夫だよ。いつも通りで。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：はい、分かりました！", ActionEvent.None);

            Message(ref m_list, ref e_list, "<==== " + FIX.TOWN_FAZIL_CASTLE + "、エントランスにて ====>", ActionEvent.HomeTownMessageDisplay);

            Message(ref m_list, ref e_list, "ラナ：じゃあ、まずは" + FIX.TOWN_COTUHSYE + "へ向かえば良いみたいね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ、遠征許可証も手に入れたし、そろそろ出発するか。ラナ、準備は良いか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：ええ、いつでも良いわよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：オーケー！じゃあ、行くとするか！", ActionEvent.None);

            Message(ref m_list, ref e_list, "", ActionEvent.None);
        }
        public static void Message100040(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message100040 = true;

            Message(ref m_list, ref e_list, "アイン：じゃあ、いざ出発！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：あら、ちょって待ってアイン。街の出入り口に誰かいるみたいよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ん、本当だな・・・誰だ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "？？？：あ、あの。すみません・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：よう、こんにちわ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "？？？：あの・・・私・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：えっと、なんか用か？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：ちょっと、バカアイン。あんたは引っ込んでなさい。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：なぜ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：いいから、任せておいて。", ActionEvent.None);

            Message(ref m_list, ref e_list, "？？？：あの・・・スミマセン・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：こんにちわ、はじめまして。", ActionEvent.None);

            Message(ref m_list, ref e_list, "？？？：あ、はじめまして、私はエオネ・フルネアと申します。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：私はラナ・アミリアよ。よろしくね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "エオネ：あっ、えっと。よろしくおねがいします。", ActionEvent.None);

            Message(ref m_list, ref e_list, "エオネ：あの！今日は、し、仕事の依頼があって参りました！", ActionEvent.None);

            Message(ref m_list, ref e_list, "エオネ：私を" + FIX.TOWN_QVELTA_TOWN + "までお送りいただけないでしょうか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：おお、俺たちもそこは通過するつもりだ。タイミングが良いな！", ActionEvent.None);

            Message(ref m_list, ref e_list, "エオネ：え、えっと、あの・・・その" + FIX.TOWN_QVELTA_TOWN + "まで・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：（ちょっ、バカアイン出てくるとややこしいから、引っ込んでてよ）", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：（あ、あぁ・・・）", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：" + FIX.TOWN_QVELTA_TOWN + "まで護衛して欲しいって事よね、承知したわ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "エオネ：あ、ありがとうございます！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：確認なんだけど、一般市民としてかしら？それとも、戦闘は何か出来る？", ActionEvent.None);

            Message(ref m_list, ref e_list, "エオネ：え、えっと。多少の水魔法は使えます。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：じゃあ、戦闘グループとして同行してもらう形のほうが良いかしら？", ActionEvent.None);

            Message(ref m_list, ref e_list, "エオネ：ハ、ハイ！喜んで！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：決まりみたいね♪　じゃあ、" + FIX.TOWN_QVELTA_TOWN + "まで、一緒に行きましょう♪", ActionEvent.None);

            Message(ref m_list, ref e_list, "エオネ：あ、ありがとうございます！よろしくお願いします！", ActionEvent.None);

            Message(ref m_list, ref e_list, " 【エオネ・フルネア】が仲間になりました！", ActionEvent.HomeTownMessageDisplay);

            Message(ref m_list, ref e_list, "", ActionEvent.None);
        }
        #endregion

        #region "クヴェルタ街"
        public static void Message200010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message200010 = true;

            Message(ref m_list, ref e_list, "アイン：よし、"+FIX.TOWN_QVELTA_TOWN + "に到着したみたいだな。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：ねえ、ちょっと寄っていきたい所があるんだけど良いかしら？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ、構わねえぜ。どこに行くんだ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：武器屋を営んでいるヴァスタ叔父さんの所よ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ヴァスタ叔父さん？って誰だっけ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：ちょっと、私達が小さい頃に会ってるじゃない。忘れたの？", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：あ、ああ！覚えてるぜ！名前を聞いてもちょっとピンと来なかったからさ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：フルネア、お前はヴァスタって叔父さんの事、知ってるか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "フルネア：え、えっと・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：そこのバカアイン、何勝手に話しかけてるのよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：え、いやフルネアさんなら何か噂とか聞いたことあるのかなって思っただけだが・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：無理に答えなくて良いのよ。バカが何か適当に喋ってるだけだから。", ActionEvent.None);

            Message(ref m_list, ref e_list, "フルネア：え・・・えぇ・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：じゃ、その武器屋のおっちゃんの所へ行くとするか！", ActionEvent.None);

            Message(ref m_list, ref e_list, "", ActionEvent.None);
        }
        public static void Message200020(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message200020 = true;

            Message(ref m_list, ref e_list, "アイン：ごめんくださーい。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：あいよ！いらっしゃい！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：あっ、ヴァスタおじさま、お久しぶりです♪", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：お、おぉー、ラナちゃんか！大きくなったな！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：そちらのもうひとりのお嬢ちゃんは？", ActionEvent.None);

            Message(ref m_list, ref e_list, "フルネア：あっ・・・エオネ・フルネアと言います、よろしくお願いします。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：おお、そうかそうか。よろしくな、お嬢ちゃん。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ラナ、ヴァスタおじさんに用があってきたんだろ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：うん、ちょっと待ってね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：えとね・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：あ。あったわ、ヴァスタおじさま♪　この武具を見て欲しいんだけど・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：武具鑑定か！よし、任せておきなさい！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：どれどれ・・・ふーむ・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：・・・ぉお・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：おおおおおぉぉぉ、こ、こ、これは！！！", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：なんだなんだ？ひょっとして大当たりか！？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：ぜんぜん、解明できん！！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：ガッハハハハ！！！", ActionEvent.None);
            
            Message(ref m_list, ref e_list, "アイン：マジか、しかし鑑定出来ないなんて事もあるんだな。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：でもさ。これってアクセサリーの一種だと思ったんだけどな。違うのか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：いや、ワシも最初はそう思ったのじゃが、どうも解析しきらんエッセンスがあるようでのう。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：そうか。まあ俺は鑑定出来ないしな。基本、ヴァスタ爺さんに任せるしかないわけだが・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：そういや、ラナ。こんな代物、いつの間に持っていたんだ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：え、何よ！！？　し、し、知らないわよ！", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：うお、そんな焦らなくても良いだろ。悪かった、単に聞いただけだって。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：すまんが、ラナちゃん。このアイテム。もうしばらく鑑定させてくれ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：あ、よろしくお願いします♪", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：よし、じゃあそのアイテムは、ヴァスタのおっちゃんに頼むとするか！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：うむ、任せなさい。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：しかし、こちらかもすまぬが、一つだけ頼み事を聞いてもらえんかね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ、なんでも言ってくれ。引き受けられる内容ならいくらでもやるぜ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：ふむ・・・鑑定についてだが、実は鑑定用の機材が一部不足しておるのだ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：なるほど、取ってくれば良いんだな？了解了解！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：話が早くて助かる。ここから少し北に行き、" +FIX.FIELD_ARTHARIUM_FACTORY + "に行って欲しい。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：そこで、ゼタニウム鉱石を５つ取ってきて欲しいのじゃが、どうだろうか。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：" + FIX.FIELD_ARTHARIUM_FACTORY + "だな、わかったぜ。ラナ、後でマップ確認を頼んだぜ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：ええ、良いわよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：あそこはモンスターも出てくるという噂を聞いておる。準備は万全にな。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：オーケー！じゃあ、ゼタニウム鉱石を取ってきたらまた戻ってくるぜ。少し待っててくれよな。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：すまんが、よろしく頼む。", ActionEvent.None);

            Message(ref m_list, ref e_list, "", ActionEvent.None);
        }
        public static void Message200030(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message200030 = true;

            Message(ref m_list, ref e_list, "アイン：ども、こんちわー", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：おー、アインか。いらっしゃい！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：前にお願いしていたゼタニウム鉱石を持ってきました♪", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：お、そいつは嬉しいねえ！では、早速例のアイテムの鑑定を行うとするかの！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：ちなみに、そのゼタニウム鉱石は５つあるから２５００ＧＯＬＤで引き取るぞ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：えっ、ちょっとお金なんていいですよ。そんなつもりで持ってきたんじゃないですし。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：ええからええから。ワシとて商売人。売買は人との礼儀そのもの。取っておくがよい。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：すみません、ではありがたく頂戴します。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：鉱石の中に、超微細レンズの仕組みを担う物質が含まれておってな。それをちょっと抽出してくる。待っておれ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：よろしくおねがいします！", ActionEvent.None);

            Message(ref m_list, ref e_list, "　～　しばらくして　～　", ActionEvent.HomeTownMessageDisplay);

            Message(ref m_list, ref e_list, "ヴァスタ：よし、レンズが完成したぞ。これじゃ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：え？その今見せてくれている手のひらに何かあるんですか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：あるに決まっておるじゃろう。何を言うとるか。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：そ、そうなんだ。全然見えねえぞ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：ホントね・・・光の反射でほんの僅かに見える程度ね。普通には見えないレベルだわ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：まあ、見ておれ。これで例のアイテムを鑑定する。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：・・・　・・・　・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：・・・　・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：ふむ・・・む・・・。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：どうだ、結果は・・・？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：正直に言おう。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：これは鑑定は出来ても、ワシ単独では解読はできん。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：どういう事ですか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：まずは、鑑定結果を伝えよう。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：このアイテムのカテゴリは『武器』となる。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：マジかよ！？こんな小さな形状のリングがか！？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：うむ、間違いない。このリングの内部に極小の窪みがあっての。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：そこに、文字が書かれておった。内容はこうじゃ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "　　『　封じられしはラタの蒼き門。放たれしはシスの朱き詩』", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：何だそれ・・・聞いたことねえな・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "フルネア：・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：あれ、なんで皆黙ってんだよ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：今度、私が後で丁寧に教えてあげるわよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：えっ、ていうか何でそれで『武器』って事になるんだよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：それも、私が後で丁寧に教えてあげるわよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：いやいや、教えてくれよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：だから、私が後で丁寧に教えてあげるわよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：マジか・・・。", ActionEvent.None);

            Message(ref m_list, ref e_list, "フルネア：・・・ッ・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ん？どうした？", ActionEvent.None);

            Message(ref m_list, ref e_list, "フルネア：いえ、なんでも！", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：まあ、いいか。詳しくはまた今度教えてくれ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：ゴッホン、とにかく鑑定自体は完了じゃ。後はお主ら次第。このアイテムは返しておくかの。", ActionEvent.None);

            Message(ref m_list, ref e_list, "～　【法剣？？？】を手に入れた！　～", ActionEvent.HomeTownMessageDisplay);

            Message(ref m_list, ref e_list, "ラナ：鑑定、ありがとうございました♪", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：よし。じゃあ、ありがとうな、ヴァスタのおっさん！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ヴァスタ：おっさんか！ガハハハハ！また好きな時にどんとこい。いくらでも付き合うぞ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ、またよろしくな！", ActionEvent.None);

            Message(ref m_list, ref e_list, "", ActionEvent.None);
        }
        #endregion

        #region "アーサリウム工場跡地"
        public static void Message300010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message300010 = true;

            Message(ref m_list, ref e_list, "アイン：よし" + FIX.FIELD_ARTHARIUM_FACTORY + "に着いたみたいだな。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：・・・大量のガラクタがそこら中に散らばってるわね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：フルネア、足元に危ない破片が落ちてるわ。気をつけてね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "フルネア：あ、ありがとうございます。気をつけます。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：なあ、ここは特に街ってワケでもなさそうだから、無理せず待っててくれても良いんだぞ？", ActionEvent.None);

            Message(ref m_list, ref e_list, "フルネア：あ、いえ。大丈夫です。わ、私、その・・・慣れてますから・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：あれ？慣れてるのか？", ActionEvent.None);

            Message(ref m_list, ref e_list, "フルネア：あ、いえ・・・え、ええと・・・その・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：ちょっと、バカアインはなんでそう人の気持ちにズカズカと踏み込んでるのよ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：バカな。俺はそんな特別な会話はしてないつもりだが・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：フルネア、足元も注意だけど、そこのバカアインとの会話にも要注意だからね。", ActionEvent.None);

            Message(ref m_list, ref e_list, "フルネア：あ・・・はい、わかりました。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：うお・・・マジか・・・", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：よし、わかった。じゃあ次からはもう少し気をつけて喋りかける。", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：それよりも、ゼタニウム鉱石を発掘しないといけないのよね。早く始めましょ。", ActionEvent.None);

            Message(ref m_list, ref e_list, "アイン：ああ、じゃあ早速この辺りを探索開始といきますか！", ActionEvent.None);

            Message(ref m_list, ref e_list, "", ActionEvent.None);
        }

        public static void Message300020(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message300020 = true;
            ONE.WE2.Zetanium_001 = true;

            Message30002X(ref m_list, ref e_list);
        }

        public static void Message300021(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message300021 = true;
            ONE.WE2.Zetanium_002 = true;
            Message30002X(ref m_list, ref e_list);
        }
        public static void Message300022(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message300022 = true;
            ONE.WE2.Zetanium_003 = true;
            Message30002X(ref m_list, ref e_list);
        }
        public static void Message300023(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message300023 = true;
            ONE.WE2.Zetanium_004 = true;
            Message30002X(ref m_list, ref e_list);
        }
        public static void Message300024(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            ONE.WE2.Event_Message300024 = true;
            ONE.WE2.Zetanium_005 = true;
            Message30002X(ref m_list, ref e_list);
        }

        private static void Message30002X(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            Message(ref m_list, ref e_list, "アイン：おっ、ゼタニウム鉱石を発見っと！", ActionEvent.None);

            Message(ref m_list, ref e_list, "ラナ：やるじゃない♪", ActionEvent.None);

            if (GetZetaniumCount() == 1)
            {
                Message(ref m_list, ref e_list, "アイン：とりあえずは１個ゲットといった所だな。", ActionEvent.None);

                Message(ref m_list, ref e_list, "ラナ：残り４つは見つける必要があるわね。", ActionEvent.None);

                Message(ref m_list, ref e_list, "アイン：ああ、引き続き探索を続けよう。", ActionEvent.None);
            }
            else if (GetZetaniumCount() == 2)
            {
                Message(ref m_list, ref e_list, "アイン：よし、これで２個目だぜ。", ActionEvent.None);

                Message(ref m_list, ref e_list, "ラナ：まだ３つ見つける必要があるわね。", ActionEvent.None);

                Message(ref m_list, ref e_list, "アイン：ああ、引き続き探索を続けよう。", ActionEvent.None);
            }
            else if (GetZetaniumCount() == 3)
            {
                Message(ref m_list, ref e_list, "アイン：ようやく、これで合計３つだな。", ActionEvent.None);

                Message(ref m_list, ref e_list, "ラナ：残る２つも、うまく見つかると良いわね。", ActionEvent.None);

                Message(ref m_list, ref e_list, "アイン：ああ、引き続き探索を続けよう。", ActionEvent.None);
            }
            else if (GetZetaniumCount() == 4)
            {
                Message(ref m_list, ref e_list, "アイン：おっしゃ、きたきた！４つ目ゲット！", ActionEvent.None);

                Message(ref m_list, ref e_list, "ラナ：後１つよ、慎重に探してよね。", ActionEvent.None);

                Message(ref m_list, ref e_list, "アイン：分かってるって。じゃ、引き続き探索を続けよう。", ActionEvent.None);
            }
            else if (GetZetaniumCount() == 5)
            {
                Message(ref m_list, ref e_list, "アイン：やったぜ、これで５つ揃ったな！", ActionEvent.None);

                Message(ref m_list, ref e_list, "ラナ：フフ、やったじゃない、おめでとう♪", ActionEvent.None);

                Message(ref m_list, ref e_list, "アイン：いやー、サンキューサンキュー。ありがとな！", ActionEvent.None);

                Message(ref m_list, ref e_list, "フルネア：あ、おめでとうございます。", ActionEvent.None);

                Message(ref m_list, ref e_list, "アイン：おお、フルネアも戦闘は助かったぜ、サンキューな！", ActionEvent.None);

                Message(ref m_list, ref e_list, "ラナ：じゃあ、一旦" + FIX.TOWN_QVELTA_TOWN + "に戻って、ヴァスタおじさまに渡しに行きましょ。", ActionEvent.None);

                Message(ref m_list, ref e_list, "アイン：オーケー、了解！！", ActionEvent.None);
            }

            Message(ref m_list, ref e_list, "", ActionEvent.None);
        }

        public static int GetZetaniumCount()
        {
            int counter = 0;
            if (ONE.WE2.Zetanium_001)
            {
                counter++;
            }
            if (ONE.WE2.Zetanium_002)
            {
                counter++;
            }
            if (ONE.WE2.Zetanium_003)
            {
                counter++;
            }
            if (ONE.WE2.Zetanium_004)
            {
                counter++;
            }
            if (ONE.WE2.Zetanium_005)
            {
                counter++;
            }
            return counter;
        }
        #endregion

        #region "港町コチューシェ"
        public static void Message400010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ツァルマンの里"
        public static void Message500010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ゴルトラム洞窟"
        public static void Message600010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ファージル宮殿"
        public static void Message700010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "オーランの塔"
        public static void Message800010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "フィオーネの湖"
        public static void Message900010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ヴェルガスの海底神殿"
        public static void Message1000010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "アーケンダインの街"
        public static void Message1100010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "廃墟サリタン"
        public static void Message1200010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "離島ウォズム"
        public static void Message1300010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ダルの門"
        public static void Message1400010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ディルの街"
        public static void Message1500010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ディスケル戦場跡"
        public static void Message1600010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ガンロー要塞"
        public static void Message1700010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ロスロンの洞窟"
        public static void Message1800010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "エデルガイゼン城"
        public static void Message1900010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ゼールマンの里"
        public static void Message2000010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "ラタの小屋"
        public static void Message2100010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "パルメティシア神殿"
        public static void Message2200010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "雪原の大樹ラタ"
        public static void Message2300010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "シスの墓石"
        public static void Message2400010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "キルクード山岳地帯"
        public static void Message2500010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        #region "天上界ジェネシスゲート"
        public static void Message2600010(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
        }
        #endregion

        public static void Message(ref List<string> m_list, ref List<ActionEvent> e_list, string message, ActionEvent eventData)
        {
            m_list.Add(message);
            e_list.Add(eventData);
        }
    }
}
