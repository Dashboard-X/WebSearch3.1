using System;
using System.Collections.Generic;
using System.Text;

namespace WebSearch.Model.Net
{
    /// <summary>
    /// For English POS Tag:
    /// http://bioie.ldc.upenn.edu/wiki/index.php/POS_tags
    /// 
    /// For Chinese POS Tag
    /// http://www.nlp.org.cn/docs/20030724/resource/specification.htm
    /// 名词n、时间词t、处所词s、方位词f、数词m、量词q、区别词b、代词r、动词v、
    /// 形容词a、状态词z、副词d、介词p、连词c、助词u、语气词y、叹词t、拟声词o、
    /// 成语i、习用语l、简称j、前接成分h、后接成分k、语素g、非语素字x、标点符号w、
    /// 人名nr，地名ns，团体机关单位名称nt，其他专有名词nz
    /// </summary>
    public static class POSTag
    {
        #region POS Tag: Symbols

        public static bool IsSymbol(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.DollarSign || posTag == POSTag.LRB ||
                posTag == POSTag.RBR || posTag == POSTag.HYPH || 
                posTag == POSTag.SYM || posTag == POSTag.W)
                return true;
            else return false;
        }

        /// <summary>
        /// In the Penn Treebank, this tag is used for currency symbols.
        /// It doesn't occur in the Bio-Med corpus
        /// </summary>
        public const string DollarSign = "$";

        /// <summary>
        /// Notwithstanding that the tags stand for "left round bracket" and 
        /// "right round bracket", tag as -LRB- and -RRB- any paired symbols
        /// used as brackets: ( ) [ ] { } < >, regardless of shape, except 
        /// where they are part of a construction that should be tagged as a 
        /// whole rather than split. 
        /// </summary>
        public const string LRB = "-LRB-";
        public const string RRB = "-RRB-";

        /// <summary>
        /// Hyphen 
        /// Use this tag for the hyphen (-) character when it is used as a normal
        /// piece of English punctuation. In general, hyphenated compound words
        /// should be split into their components, but there are exceptions.
        /// In addition, this character has many other uses, and appears in many 
        /// confusing or difficult-to-tag constructions. 
        /// </summary>
        public const string HYPH = "HYPH";

        /// <summary>
        /// Symbol 
        /// This tag should be used for mathematical, scientific and technical
        /// symbols or expressions that aren't words of English. It should not
        /// used for any and all technical expressions. For instance, the names
        /// of chemicals, units of measurements (including abbreviations thereof)
        /// and letters of our ("Roman" or "Latin") alphabet , such as 
        /// A B C ..., are tagged as nouns (NN). 
        /// 1. The plus sign "+" and minus sign "-" when indicating positive or negative numbers 
        /// 2. The plus-or-minus sign ±, which in our texts generally appears as +/- 
        /// 3. English punctuation used in the name of a mutation 
        /// 4. (R) standing for the registered trademark symbol ®. Similarly © and ™, if they ever appear. 
        /// 5. Arrows
        /// </summary>
        public const string SYM = "SYM";

        /// <summary>
        /// 标点符号
        /// </summary>
        public const string W = "W";

        #endregion

        #region POS Tag: Adjective

        public static bool IsAdjective(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.A || posTag == POSTag.JJ ||
                posTag == POSTag.JJR || posTag == POSTag.JJS)
                return true;
            else return false;
        }

        /// <summary>
        /// Adjective
        /// 1. To describe or modify a noun or pronoun
        /// 2. "-ic" Endings 
        /// 3. Ordinal Numbers 
        /// </summary>
        public const string JJ = "JJ";
        public const string A = "A";

        /// <summary>
        /// Adjective, comparative 
        /// Adjectives with the comparative ending -er and a comparative meaning are tagged JJR. 
        /// More and less when used as adjectives, as in more or less mail, are also tagged as JJR. 
        /// More and less can also be tagged as JJR when they occur by themselves. 
        /// Adjectives with a comparative meaning but without the comparative ending -er, like superior,
        /// should simply be tagged as JJ. Adjectives with the ending -er but without a strictly 
        /// comparative meaning ("more X"), like further in further details, should also simply be tagged as JJ. 
        /// </summary>
        public const string JJR = "JJR";

        /// <summary>
        /// Adjective, superlative 
        /// Adjectives with the superlative ending -est (as well as worst) are 
        /// tagged as JJS. Most and least when used as adjectives, as in 
        /// the most or the least mail, are also tagged as JJS. Most and least
        /// can also be tagged as JJS when they occur by themselves; 
        /// </summary>
        public const string JJS = "JJS";

        #endregion

        #region POS Tag: Noun

        public static bool IsNoun(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.N || posTag == POSTag.NN || 
                posTag == POSTag.NNP || posTag == POSTag.NNPS ||
                posTag == POSTag.NNS || posTag == POSTag.NS ||
                posTag == POSTag.NR || posTag == POSTag.NT ||
                posTag == POSTag.VN)
                return true;
            else return false;
        }

        public static bool IsProperNoun(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.NNP || posTag == POSTag.NNPS ||
                posTag == POSTag.NS || posTag == POSTag.NR ||
                posTag == POSTag.NT)
                return true;
            else return false;
        }

        /// <summary>
        /// Noun, singular common 
        /// In regular English grammar, a noun refers to "an entity, quality,
        /// state, action, or concept". (Merriam-Webster). Since annotators 
        /// rarely have the the domain knowledge required to fully understand 
        /// the meaning of the biomedical files, we use NN as a default tag 
        /// for many unfamiliar terms. 
        /// 1. Hyphenated numbers (not referring to a range) should be 
        /// tagged NN because they refer to a chemical name. 
        /// 2. Digit/letter combinations should all be tagged NN. 
        /// 3. Gerunds 
        /// </summary>
        public const string NN = "NN";
        public const string N = "N";

        /// <summary>
        /// 人名
        /// </summary>
        public const string NR = "NR";

        /// <summary>
        /// 地名
        /// </summary>
        public const string NS = "NS";

        /// <summary>
        /// 团体机关单位名称
        /// </summary>
        public const string NT = "NT";

        /// <summary>
        /// verb used as noun
        /// </summary>
        public const string VN = "VN";

        /// <summary>
        /// Noun, singular proper 
        /// There are few proper nouns in these files, mostly names of individual
        /// persons or organizations. Proper names of persons, organizations, 
        /// places, and species names should be tagged as NNP.
        /// 1. Individuals 
        /// 2. Organizations 
        /// 3. Places
        /// 4. Species names 
        /// </summary>
        public const string NNP = "NNP";

        /// <summary>
        /// Noun, plural proper 
        /// Use this tag for nouns that are both proper (see above) and plural (see below). 
        /// </summary>
        public const string NNPS = "NNPS";

        /// <summary>
        /// Noun, plural common 
        /// </summary>
        public const string NNS = "NNS";

        #endregion

        #region POS Tag: Pronoun

        public static bool IsPronoun(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.R || posTag == POSTag.PRP ||
                 posTag == POSTag.PRPs || posTag == POSTag.WP ||
                 posTag == POSTag.WPs)
                return true;
            else return false;
        }

        public const string R = "R";

        /// <summary>
        /// Personal pronoun 
        /// This category includes the personal pronouns proper, without regard for 
        /// case distinctions (I , me, you, he, him, etc.), the reflexive pronouns 
        /// ending in -self or -selves, and the nominal possessive pronouns mine,
        /// yours, his, hers, ours and theirs. The adjectival possessive forms my,
        /// your, his, her, its, our and their, on the other hand, are tagged PRP$. 
        /// </summary>
        public const string PRP = "PRP";

        /// <summary>
        /// Personal pronoun, possessive 
        /// This category includes the adjectival possessive forms my, your, his, 
        /// her, its, one's,* our and their. The nominal possessive pronouns mine, 
        /// yours, his, hers, ours and theirs are tagged as personal pronouns (PRP). 
        /// </summary>
        public const string PRPs = "PRP$";

        /// <summary>
        /// Wh-pronoun 
        /// This tag includes what, who and whom. 
        /// </summary>
        public const string WP = "WP";

        /// <summary>
        /// Wh-pronoun, possessive 
        /// This category includes the wh-word whose
        /// </summary>
        public const string WPs = "WP$";

        #endregion

        #region POS Tag: Adverb

        public static bool IsAdverb(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.D || posTag == POSTag.RB ||
                posTag == POSTag.RBR || posTag == POSTag.RBS)
                return true;
            else return false;
        }

        /// <summary>
        /// Adverb 
        /// This category includes most words that end in -ly as well as degree
        /// words like quite, too and very, posthead modifiers like enough and
        /// indeed (as in good enough, very well indeed), and negative markers 
        /// like not, n't and never. 
        /// </summary>
        public const string RB = "RB";
        public const string D = "D";

        /// <summary>
        /// Adverb, comparative 
        /// This tag refers to an adverb that expresses whether or not one item
        /// posesses a predetermined quality in a greater or lesser degree in
        /// comparision to another item. More and less can be used as comparative adverbs.
        /// </summary>
        public const string RBR = "RBR";

        /// <summary>
        /// Adverb, superlative 
        /// The RBS tag refers to an adverb that expresses whether or not an 
        /// item has a predetermined quality to a greater or lesser degree.
        /// </summary>
        public const string RBS = "RBS";

        #endregion

        #region POS Tag: Verb

        public static bool IsVerb(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.VB || posTag == POSTag.VBD ||
                posTag == POSTag.VBG || posTag == POSTag.VBN ||
                posTag == POSTag.VBP || posTag == POSTag.VBZ ||
                posTag == POSTag.MD || posTag == POSTag.V)
                return true;
            else return false;
        }

        /// <summary>
        /// Verb, base form 
        /// This tag subsumes imperatives, infinitives, and subjunctives
        /// 1. Imperative
        /// 2. Infinitive
        /// 3. Subjunctive
        /// </summary>
        public const string VB = "VB";
        public const string V = "V";

        /// <summary>
        /// Verb, past tense 
        /// This tag includes all past tense verbs, including the conditional 
        /// form of the verb to be.
        /// </summary>
        public const string VBD = "VBD";

        /// <summary>
        /// Verb, present participle 
        /// VBG refers to the form of a verb that ends in -ing, also called 
        /// a gerund. VBGs can be used in their strictly verbal form, as
        /// an adjective, or as a noun. 
        /// 1. Used verbally
        /// 2. Used as a noun
        /// 3. Used as an adjective: See the JJ or VBG/VBN Guidelines
        /// </summary>
        public const string VBG = "VBG";

        /// <summary>
        /// Verb, past participle 
        /// This tag refers to the form a verb that ends in -ed (for regular verbs)
        /// or in alternate forms (for irregular verbs) and describes nouns that 
        /// are the object of the action of the verb. 
        /// </summary>
        public const string VBN = "VBN";

        /// <summary>
        /// Verb, present tense, not 3rd person singular 
        /// The VBP tag refers to a present tense verb, not 3rd person singular. 
        /// Take care to correct VB to VBP where appropriate
        /// </summary>
        public const string VBP = "VBP";

        /// <summary>
        /// Verb, present tense, 3rd person singular 
        /// The VBZ tag refers to a present tense verb, 3rd person singular. 
        /// </summary>
        public const string VBZ = "VBZ";

        /// <summary>
        /// Modal verb 
        /// This category includes all verbs that don't take an -s ending in the 
        /// third person singular present: can, could, (dare), may, might, must, 
        /// ought, shall, should, will, would.
        /// </summary>
        public const string MD = "MD";

        #endregion

        #region POS Tag: Numeral

        public static bool IsNumeral(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.M || posTag == POSTag.CD)
                return true;
            else return false;
        }

        /// <summary>
        /// Cardinal number 
        /// Use this tag for expessions that represent specific numbers, 
        /// including numerals, Roman numerals, and spelled-out number words. 
        /// </summary>
        public const string CD = "CD";
        public const string M = "M";

        #endregion

        #region POS Tag: Time

        public static bool IsTime(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.T)
                return true;
            else return false;
        }

        public const string T = "T";

        #endregion

        #region POS Tag: Conjunction

        public static bool IsConjunction(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.C || posTag == POSTag.CC || 
                posTag == POSTag.WRB)
                return true;
            else return false;
        }

        /// <summary>
        /// Coordinating conjunction 
        /// 1. the mathematical operators plus, minus, less, times (in the sense
        /// of "multiplied by") and over (in the sense of "divided by"), when they 
        /// are spelled out.
        /// 2. and, but, nor, or, yet (as in Yet it's cheap, cheap yet good) 
        /// 3. both, either and neither when they are the first members of the
        /// double conjunctions both...and, either...or and neither...nor.
        /// </summary>
        public const string CC = "CC";
        public const string C = "C";

        /// <summary>
        /// Wh-adverb 
        /// This category includes how, where, why, etc. 
        /// When in a temporal sense is tagged as a Wh-adverb (WRB). In the sense of if,
        /// on the other hand, it is a subordinating conjunction (IN). 
        /// </summary>
        public const string WRB = "WRB";

        #endregion

        #region POS Tag: Preposition

        public static bool IsPreposition(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.IN || posTag == POSTag.P)
                return true;
            else return false;
        }

        /// <summary>
        /// Preposition or subordinating conjunction
        /// We make no explicit distinction between prepositions and subordinating
        /// conjunctions. (The distinction is not lost, however — a preposition is
        /// an IN that precedes a noun phrase or a prepositional phrase, 
        /// and a subordinate conjunction is an IN that precedes a clause.) 
        /// Words like though, although, and whereas are subordinating conjunctions. 
        /// </summary>
        public const string IN = "IN";
        public const string P = "P";

        #endregion

        #region POS Tag: Quantifier

        public static bool IsQuantifier(string posTag)
        {
            posTag = posTag.Trim().ToUpper();
            if (posTag == POSTag.Q)
                return true;
            else return false;
        }

        /// <summary>
        /// Quantifier
        /// </summary>
        public const string Q = "Q";

        #endregion

        #region POS Tag: Others

        /// <summary>
        /// 处所词
        /// </summary>
        public const string S = "S";

        /// <summary>
        ///方位词
        /// </summary>
        public const string F = "F";

        /// <summary>
        /// 区别词
        /// </summary>
        public const string B = "B";

        /// <summary>
        /// 状态词
        /// </summary>
        public const string Z = "Z";

        /// <summary>
        /// 助词
        /// </summary>
        public const string U = "U";

        /// <summary>
        /// 语气词
        /// </summary>
        public const string Y = "Y";

        /// <summary>
        /// 叹词
        /// </summary>
        public const string E = "E";

        /// <summary>
        /// 拟声词
        /// </summary>
        public const string O = "O";

        /// <summary>
        /// 成语
        /// </summary>
        public const string I = "I";

        /// <summary>
        /// 习用语
        /// </summary>
        public const string L = "L";

        /// <summary>
        /// 简称
        /// </summary>
        public const string J = "J";

        /// <summary>
        /// 前接成分
        /// </summary>
        public const string H = "H";

        /// <summary>
        /// 后接成分
        /// </summary>
        public const string K = "K";

        /// <summary>
        /// 语素
        /// </summary>
        public const string G = "G";

        /// <summary>
        /// 非语素字
        /// </summary>
        public const string X = "X";

        /// <summary>
        /// AFX is for English affixes, such as non-, anti-, pro-, as well as
        /// components of (bio)chemical words, like azo-, azoxy-, and hydro-.
        /// Medical components, too. Do not split off a prefix when it is connected
        /// directly, without a hyphen (or conceivable other punctuation).
        /// </summary>
        /// <example>nonfunctioning, antimalarial, precancerous</example>
        public const string AFX = "AFX";

        /// <summary>
        /// Determiner 
        /// This category includes the articles a(n), every, no and the,
        /// the indefinite determiners another, any and some, each, 
        /// either (as in either way), neither (as in neither decision),
        /// that, these, this and those, and instances of all and both 
        /// when they do not precede a determiner or possessive pronoun
        /// (as in all roads or both times). Instances of all or both that
        /// do precede a determiner or possessive pronoun are tagged as 
        /// predeterminers (PDT). 
        /// </summary>
        public const string DT = "DT";

        /// <summary>
        /// Existential there 
        /// Existential there is the unstressed there that triggers inversion
        /// of the inflected verb and the logical subject of a sentence.
        /// </summary>
        public const string EX = "EX";

        /// <summary>
        /// Foreign word 
        /// The FW tag is used for foreign (non-English) words and phrases. 
        /// In biomedical text, these are almost all Latin.
        /// </summary>
        public const string FW = "FW";

        /// <summary>
        /// List item
        /// This category includes letters and numerals when they are used to identify
        /// items in a list. Any punctuation associated with a list item marker 
        /// should be included in the same token. 
        /// </summary>
        public const string LS = "LS";

        /// <summary>
        /// Predeterminer 
        /// This category includes the following determiner-like elements such as all,
        /// nary, both, quite, half, rather, many, and such when they precede an 
        /// article or possessive pronoun. 
        /// </summary>
        public const string PDT = "PDT";

        /// <summary>
        /// Possessive 
        /// The possessive ending on nouns ending in 's or ' is split off by the
        /// tagging algorithm and tagged as if it were a separate word. 
        /// </summary>
        public const string POS = "POS";

        /// <summary>
        /// Particle 
        /// This category includes a number of mostly monosyllabic words that 
        /// also double as directional adverbs and prepositions. Consult the
        /// IN or RB Guidelines, IN or RP Guidelines, and RB or RP Guidelines
        /// for further information.
        /// </summary>
        public const string RP = "RP";

        /// <summary>
        /// The word to is tagged TO, regardless of whether it is a preposition or an infinitival marker
        /// </summary>
        public const string TO = "TO";

        /// <summary>
        /// Untagged token 
        /// This is the tag placed by the tokenizer when it breaks the text up into tokens.
        /// If a POS annotator sees it, it means that a token wasn't tagged by the automatic
        /// POS tagger, or was split and left untagged by another annotator earlier in the
        /// annotation process. This tag is never correct — it should not appear on text
        /// that is to be annotated. 
        /// </summary>
        public const string token = "token";

        /// <summary>
        /// Interjection
        /// In the Penn Treebank, this tag is used for exclamations and interjections.
        /// This doesn't occur in the Bio-Med corpus.
        /// </summary>
        public const string UH = "UH";

        /// <summary>
        /// Wh-determiner 
        /// This tag includes which, as well as that when it is used as a relative pronoun. 
        /// </summary>
        public const string WDT = "WDT";

        #endregion
    }
}
