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

        public static List<string> m_list = new List<string>();
        public static List<ActionEvent> e_list = new List<ActionEvent>();

        #region "ホームタウン"
        public static void Message10001(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            m_list.Add("アイン：っしゃ・・・これで準備OKかな。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：え、ちょっとそれだけしか持っていかないワケ？"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：旅に出るんだ。荷物はこれぐらい軽くしておいたほうが良いだろ。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：旅に出るわけじゃなくて、周辺調査に行くのよ。ちゃんと準備してよね、ホント。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：大丈夫だって、オーケーオーケー！ッハッハッハ！"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：頭痛がしてきたわ・・・まったく・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：ところで、ちゃんと国外遠征許可証はそのバックパックに入ってるんでしょうね？"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：国外・・・遠征・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：許可証だと？"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：許可証を受け取りに、ファージル宮殿には行った？"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：行ってねえな。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：許可証を受領するための期限が先週までだったのは知ってるわよね？"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ウソだろ？そんな期限なんてあったか？"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：国外遠征許可証の推薦状にはちゃんと目を通したわけ？"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ああ、もちろんだ。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：その推薦状に書いてあったわよ。ちゃんと見てないわよね？"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ああ、もちろんだ。"); e_list.Add(ActionEvent.None);

            m_list.Add("『ッシャゴオォォオォォ！！！』（ラナのファイナリティ・ブローがアインに炸裂）"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：わ、分かった分かった・・・すまねえ。今から取ってくるからさ。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：本当に行くんでしょうね？今日中に出発したいんだから、頼むわよホント。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ああ、任せとけ！ッハッハッハ！"); e_list.Add(ActionEvent.None);

            m_list.Add(""); e_list.Add(ActionEvent.AutoSaveWorldEnvironment);

            m_list.Add(""); e_list.Add(ActionEvent.None);

            ONE.WE2.EventHomeTown_0001 = true;
        }

        public static void Message10002(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            m_list.Add("アイン：よし、ファージル宮殿に到着。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：正面ゲートから入ったらすぐ横の受付を済ませてちょうだいね。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ああ、わかった。了解了解！"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：って、おわぁ！！　なんで横に居るんだよ！？"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：バカアインが迷子になるのは目に見えてるからよ。しょーがないから来てあげたんじゃない。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ま・・・まあ、正直なところ宮殿はほぼ歩いた事がねえ・・・助かるけどな。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：ホラ、そこの受付に早く行って頂戴。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ああ、わかった。"); e_list.Add(ActionEvent.None);

            m_list.Add("<==== ファージル宮殿、受付口にて ====>"); e_list.Add(ActionEvent.HomeTownMessageDisplay);

            m_list.Add("　　【受付嬢：ファージル宮殿へようこそ。】"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：すまないがちょっと教えてくれ。国外遠征のための通行証が欲しいんだが。"); e_list.Add(ActionEvent.None);

            m_list.Add("　　【受付嬢：ファージル王国からの推薦状をご提示願いますでしょうか。】"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：えっ！なんだって！？"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：何言ってんのよ。さっき話してた用紙の事よ。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ああ。あの紙の事か。それならここに持ってるぜ。"); e_list.Add(ActionEvent.None);

            m_list.Add("　　【受付嬢：推薦状を拝見いたします。しばらくお待ち下さい。】"); e_list.Add(ActionEvent.None);

            m_list.Add("　　【受付嬢：・・・　・・・】"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：・・・　・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("　　【受付嬢：アイン・ウォーレンス様ですね。本日はようこそおいでくださいました。】"); e_list.Add(ActionEvent.None);

            m_list.Add("　　【受付嬢：こちらがアイン・ウォーレンス様の国外遠征許可証となります。】"); e_list.Add(ActionEvent.None);

            m_list.Add("　　【受付嬢：どうぞ、お受け取りください。】"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：サンキュー！助かるぜ！"); e_list.Add(ActionEvent.None);

            m_list.Add("　　【受付嬢：なお、エルミ・ジョルジュ国王陛下よりアイン・ウォーレンス様へ連絡があるとの事です。】"); e_list.Add(ActionEvent.None);

            m_list.Add("　　【受付嬢：本日、この国外遠征許可証をお持ちの上、必ず謁見の間へ行かれます様、よろしくお願い申し上げます。】"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：エルミ国王が・・・なんだろう。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：バカアインが許可証もらうのをサボってたから、心配してるんじゃないの？"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ハハハ・・・言われてみりゃそうかもな・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：謁見の間は宮殿の中央から３階まで上がった場所にあるわよ。早く行きましょう。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：了解！"); e_list.Add(ActionEvent.None);

            m_list.Add(""); e_list.Add(ActionEvent.None);
            
            ONE.WE2.EventHomeTown_0002 = true;
        }
        public static void Message10003(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            m_list.Add("アイン：よし、謁見の間は確かここだったな。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：じゃ、行ってきてちょうだい。失礼の無いようにね。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：あれ、ラナは入らないのかよ？"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：呼ばれたのはアインだけよ。私が入る事はできないわ。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：そうなのか。じゃあ俺一人で行ってくるぜ。"); e_list.Add(ActionEvent.None);

            m_list.Add("<==== ファージル宮殿、謁見の間にて ====>"); e_list.Add(ActionEvent.HomeTownMessageDisplay);

            m_list.Add("アイン：し、失礼つかまつります！"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：アイン君だね。ようこそファージル宮殿へ。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：この度は、ご機嫌うるわしく・・・候・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：難しい言葉は使わなくて良いよ。謁見の間では気楽に喋ってもらえれば良いから。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：は、はい。"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：ここに呼び出してしまって、すまなかったね。でも、どうしても一件頼みたい事があるんだ。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：頼みたい事？"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：国外遠征先のヴィンスガルデ王国エリアで調査して欲しい案件があるんだ。"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：案件の内容は王妃ファラから解説させようと思う。"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：こら、ファラ。変なところに隠れてないで、ちゃんと出てきてくれ。"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：フフフ。ジャーン（＾＾"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ファ、ファラ様！お、お久しゅうございます。"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：ファラ。謁見の間でかくれんぼして遊んじゃいけないって言っただろ。"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：エルミのケチンボ（＾＾＃"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：ッグ・・・ケチで言ってるわけじゃない。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ハ、ハハ・・・ええと・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：アインさん、リラックスして聞いてくださいね（＾＾"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ハイ。分かりました。"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：ファージル王国では、昔から古代アーティファクトにまつわる件を分析の対象としているの。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：古代アーティファクト？　そんなのがあるんですか？"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：伝説、古文書、語り継がれている伝承、そういったものは沢山あるのですが。"); e_list.Add(ActionEvent.None);
            
            m_list.Add("アイン：信憑性の高いものはほとんど無い・・・って所ですかね。"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：ええ、その通りです。"); e_list.Add(ActionEvent.None);

            m_list.Add("（　王妃ファラは少し真剣な眼差しを向けてきた　）"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：ヴィンスガルデ王国の歴史には一つの伝承があります。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：えっ・・・？"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：その伝承には一つのキーワードが示されています。"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：その名は【ObisidianStone】"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：Obisidian・・・Stone・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：アインさんには、そのObsidianStoneの調査を秘密裏に行っていただきたいの。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：秘密裏・・・え。どういう事ですか？"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：ファラ、そこまでで良いよ。後はボクが話すから。"); e_list.Add(ActionEvent.None);

            m_list.Add("ファラ：あら、じゃあお願いしても良いかしら（＾＾"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：アイン君。ヴィンスガルデ王国に着いたらまず、ジェミルの村へ寄って欲しい。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ジェミルの村？"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：ああ、沿岸沿いにある小さな村なんだけどね。まずはそこへ向かって欲しい。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：分かりました。じゃあ、まずはジェルミの村へ行ってみます。"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：よろしく頼んだよ。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：えっと・・・到着したら何かやる事はありますか？"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：いや、特に何かっていうのは気にしなくて良いよ。"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：天の導きがあれば、自然と道は拓かれる。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：そ、そんなもんですかね。"); e_list.Add(ActionEvent.None);

            m_list.Add("エルミ：アイン君ならきっと大丈夫だよ。いつも通りで。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：はい、分かりました！"); e_list.Add(ActionEvent.None);

            m_list.Add("<==== ファージル宮殿、エントランスにて ====>"); e_list.Add(ActionEvent.HomeTownMessageDisplay);

            m_list.Add("ラナ：じゃあ、まずはジェルミの村へ向かえば良いみたいね。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ああ、遠征許可証も手に入れたし、そろそろ出発するか。ラナ、準備は良いか？"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：ええ、いつでも良いわよ。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：オーケー！じゃあ、行くとするか！"); e_list.Add(ActionEvent.None);

            m_list.Add(""); e_list.Add(ActionEvent.None);
            
            ONE.WE2.EventHomeTown_0003 = true;
        }
        public static void Message10004(ref List<string> m_list, ref List<ActionEvent> e_list)
        {
            m_list.Add("アイン：じゃあ、いざ出発！"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：あら、ちょって待ってアイン。街の出入り口に誰かいるみたいよ。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：ん、本当だな・・・誰だ？"); e_list.Add(ActionEvent.None);

            m_list.Add("？？？：あ、あの。すみません・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：よう、こんにちわ。"); e_list.Add(ActionEvent.None);

            m_list.Add("？？？：あの・・・私・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：えっと、なんか用か？"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：ちょっと、バカアイン。あんたは引っ込んでなさい。"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：なぜ？"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：いいから、任せておいて。"); e_list.Add(ActionEvent.None);

            m_list.Add("？？？：あの・・・スミマセン・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：こんにちわ、はじめまして。"); e_list.Add(ActionEvent.None);

            m_list.Add("？？？：あ、はじめまして、私はエオネ・フルネアと申します。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：私はラナ・アミリアよ。よろしくね。"); e_list.Add(ActionEvent.None);

            m_list.Add("エオネ：あっ、えっと。よろしくおねがいします。"); e_list.Add(ActionEvent.None);

            m_list.Add("エオネ：あの！今日は、し、仕事の依頼があって参りました！"); e_list.Add(ActionEvent.None);

            m_list.Add("エオネ：私をヴィンスガルデ領のジェルミの村までお送りいただけないでしょうか？"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：おお、俺たちも今からジェルミの村へ向かう所なんだ。"); e_list.Add(ActionEvent.None);

            m_list.Add("エオネ：え、えっと、あの・・・そのジェルミの村まで・・・"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：（ちょっ、バカアイン出てくるとややこしいから、引っ込んでてよ）"); e_list.Add(ActionEvent.None);

            m_list.Add("アイン：（あ、あぁ・・・）"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：ジェルミの村まで護衛して欲しい依頼って事よね、承知したわ。"); e_list.Add(ActionEvent.None);

            m_list.Add("エオネ：あ、ありがとうございます！"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：確認なんだけど、一般市民としてかしら？それとも、戦闘は何か出来る？"); e_list.Add(ActionEvent.None);

            m_list.Add("エオネ：え、えっと。多少の水魔法は使えます。"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：じゃあ、戦闘グループとして同行してもらう形でも良いかしら？"); e_list.Add(ActionEvent.None);

            m_list.Add("エオネ：ハ、ハイ！喜んで！"); e_list.Add(ActionEvent.None);

            m_list.Add("ラナ：決まりみたいね♪　じゃあ、ジェルミの村まで、一緒に行きましょう♪"); e_list.Add(ActionEvent.None);

            m_list.Add("エオネ：よろしくお願いします！"); e_list.Add(ActionEvent.None);

            m_list.Add(" 【エオネ・フルネア】が仲間になりました！"); e_list.Add(ActionEvent.HomeTownMessageDisplay);

            m_list.Add(""); e_list.Add(ActionEvent.None);
            
            ONE.WE2.EventHomeTown_0004 = true;
        }
        #endregion

        public static void Message(ref List<string> m_list, ref List<ActionEvent> e_list, string message, ActionEvent eventData)
        {
            m_list.Add(message); e_list.Add(eventData);
        }
    }
}
