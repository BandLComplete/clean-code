using FluentAssertions;
using NUnit.Framework;

namespace Markdown
{
    [TestFixture]
    public class Md_Should
    {
        [TestCase("ab_cd_e", ExpectedResult = "ab<em>cd</em>e")]
        [TestCase("_ab_cd", ExpectedResult = "<em>ab</em>cd")]
        [TestCase("ab_cd_", ExpectedResult = "ab<em>cd</em>")]
        [TestCase("_ab_cd_e_", ExpectedResult = "<em>ab</em>cd<em>e</em>")]
        public string ChangePairedItalicsInOneParagraph(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("a_b_c_d", ExpectedResult = "a<em>b</em>c_d")]
        [TestCase("_a_b_c", ExpectedResult = "<em>a</em>b_c")]
        [TestCase("a_b_c_", ExpectedResult = "a<em>b</em>c_")]
        [TestCase("_a_b_", ExpectedResult = "<em>a</em>b_")]
        public string NotChangeNonPairedItalicsInOneParagraph(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("ab__cd__e", ExpectedResult = "ab<strong>cd</strong>e")]
        [TestCase("__ab__cd", ExpectedResult = "<strong>ab</strong>cd")]
        [TestCase("ab__cd__", ExpectedResult = "ab<strong>cd</strong>")]
        [TestCase("__ab__cd__e__", ExpectedResult = "<strong>ab</strong>cd<strong>e</strong>")]
        public string ChangePairedStrongInOneParagraph(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("a__b__c__d", ExpectedResult = "a<strong>b</strong>c__d")]
        [TestCase("__a__b__c", ExpectedResult = "<strong>a</strong>b__c")]
        [TestCase("a__b__c__", ExpectedResult = "a<strong>b</strong>c__")]
        [TestCase("__a__b__", ExpectedResult = "<strong>a</strong>b__")]
        public string NotChangeNonPairedStrongInOneParagraph(string mdText)
        {
            return Md.Render(mdText);
        }

        [TestCase("#abc", ExpectedResult = "<h1>abc</h1>")]
        [TestCase("#abc\n#cde", ExpectedResult = "<h1>abc</h1>\n<h1>cde</h1>")]
        public string ChangeHeaderAtStartOfParagraph(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("a#bc", ExpectedResult = "a#bc")]
        [TestCase("abc#", ExpectedResult = "abc#")]
        [TestCase("a#bc\ncd#e", ExpectedResult = "a#bc\ncd#e")]
        [TestCase("#ab#c", ExpectedResult = "<h1>ab#c</h1>")]
        public string NotChangeHeaderInMiddleOfParagraph(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("a_e_b__c__d", ExpectedResult = "a<em>e</em>b<strong>c</strong>d")]
        [TestCase("#a_e_b", ExpectedResult = "<h1>a<em>e</em>b</h1>")]
        [TestCase("#a__e__b", ExpectedResult = "<h1>a<strong>e</strong>b</h1>")]
        [TestCase("#a_e_b__c__d", ExpectedResult = "<h1>a<em>e</em>b<strong>c</strong>d</h1>")]
        public string ChangePairedTags_WithDifferentTags(string mdText)
        {
            return Md.Render(mdText);
        }

        [TestCase("a__b_c_d__e", ExpectedResult = "a<strong>b<em>c</em>d</strong>e")]
        public string ChangeItalics_InStrong(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("a_b__c__d_e", ExpectedResult = "a<em>b__c__d</em>e")]
        public string NotChangeStrong_InItalics(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("_1_2__3__", ExpectedResult = "_1_2__3__")]
        public string NotChangeStrongAndItalics_InNumberText(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("a_b c_d", ExpectedResult = "a_b c_d")]
        [TestCase("a__b c__d", ExpectedResult = "a__b c__d")]
        public string NotChangeStrongAndItalics_InDifferentWords(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("_ b_c", ExpectedResult = "_ b_c")]
        [TestCase("__ b__c", ExpectedResult = "__ b__c")]
        public string NotChangeStrongAndItalics_WhenSpaceAfterOpeningTag(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("_bc _", ExpectedResult = "_bc _")]
        [TestCase("__bc __", ExpectedResult = "__bc __")]
        public string NotChangeStrongAndItalics_WhenSpaceBeforeClosingTag(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("a__b", ExpectedResult = "a__b")]
        [TestCase("a____b", ExpectedResult = "a____b")]
        public string NotChangeStrongAndItalics_WhenEmptyStringInTag(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase("a_b__c_d__e", ExpectedResult = "a_b__c_d__e")]
        [TestCase("a__b_c__d_e", ExpectedResult = "a__b_c__d_e")]
        public string NotChangeStrongAndItalics_WithIntersection(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase(@"\_abc\_", ExpectedResult = "_abc_")]
        [TestCase(@"\__abc\__", ExpectedResult = "__abc__")]
        public string NotChangeStrongAndItalics_WithShield(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase(@"\abc", ExpectedResult = @"\abc")]
        public string NotRemoveShield_WithoutShielding(string mdText)
        {
            return Md.Render(mdText);
        }
        
        [TestCase(@"\\", ExpectedResult = @"\")]
        [TestCase(@"\\_abc_", ExpectedResult = @"\<em>abc</em>")]
        public string Shield_OtherShielding(string mdText)
        {
            return Md.Render(mdText);
        }
    }
}