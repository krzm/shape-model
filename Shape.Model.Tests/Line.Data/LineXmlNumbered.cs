using Xml.Generator;

namespace Shape.Model.Tests;

public class LineXmlNumbered
        : IText
{
    public string Text =>
        $"01	|<?xml version=\"1.0\" encoding=\"utf-8\"?>{Environment.NewLine}" +
        $"02	|<Line>{Environment.NewLine}" +
        $"03	|  <Context>Physic</Context>{Environment.NewLine}" +
        $"04	|  <Color>{Environment.NewLine}" +
        $"05	|    <A>255</A>{Environment.NewLine}" +
        $"06	|    <R>255</R>{Environment.NewLine}" +
        $"07	|    <G>0</G>{Environment.NewLine}" +
        $"08	|    <B>0</B>{Environment.NewLine}" +
        $"09	|    <ScA>1</ScA>{Environment.NewLine}" +
        $"10	|    <ScR>1</ScR>{Environment.NewLine}" +
        $"11	|    <ScG>0</ScG>{Environment.NewLine}" +
        $"12	|    <ScB>0</ScB>{Environment.NewLine}" +
        $"13	|  </Color>{Environment.NewLine}" +
        $"14	|  <MassCenter>{Environment.NewLine}" +
        $"15	|    <X>334</X>{Environment.NewLine}" +
        $"16	|    <Y>680</Y>{Environment.NewLine}" +
        $"17	|  </MassCenter>{Environment.NewLine}" +
        $"18	|  <Velocity>{Environment.NewLine}" +
        $"19	|    <X>0</X>{Environment.NewLine}" +
        $"20	|    <Y>0</Y>{Environment.NewLine}" +
        $"21	|  </Velocity>{Environment.NewLine}" +
        $"22	|  <IsColorFilled>True</IsColorFilled>{Environment.NewLine}" +
        $"23	|  <Mass>10</Mass>{Environment.NewLine}" +
        $"24	|  <RelativeImagePath />{Environment.NewLine}" +
        $"25	|  <SecondPoint>{Environment.NewLine}" +
        $"26	|    <X>299</X>{Environment.NewLine}" +
        $"27	|    <Y>713</Y>{Environment.NewLine}" +
        $"28	|  </SecondPoint>{Environment.NewLine}" +
        $"29	|</Line>";
}