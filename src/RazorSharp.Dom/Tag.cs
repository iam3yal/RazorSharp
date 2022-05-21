namespace RazorSharp.Dom;

using RazorSharp.Core.Strings;

public sealed record Tag : TypedString<Tag>
{
    private Tag(string value) : base(value)
    {
    }

    /// <summary>
    ///     The abbreviation tag '&lt;abbr&gt;' represents an abbreviation or acronym.
    /// </summary>
    public static Tag Abbreviation { get; } = new ("abbr");

    /// <summary>
    ///     The acronym tag '&lt;acronym&gt;' represents an acronym.
    /// </summary>
    public static Tag Acronym { get; } = new ("acronym");

    /// <summary>
    ///     The address tag '&lt;address&gt;' represents contact information for the nearest &lt;article&gt; or &lt;body&gt; ancestor.
    /// </summary>
    public static Tag Address { get; } = new ("address");

    /// <summary>
    ///     The area tag '&lt;area&gt;' defines an area inside an image map that has a hyperlink associated with it.
    /// </summary>
    public static Tag Area { get; } = new ("area");

    /// <summary>
    ///     The article tag '&lt;article&gt;' represents a self-contained composition in a document, page, application, or site.
    /// </summary>
    public static Tag Article { get; } = new ("article");

    /// <summary>
    ///     The audio tag '&lt;audio&gt;' represents sound content in a document.
    /// </summary>
    public static Tag Audio { get; } = new ("audio");

    /// <summary>
    ///     The base tag '&lt;base&gt;' specifies the base URL and/or target for all relative URLs in a document.
    /// </summary>
    public static Tag Base { get; } = new ("base");

    /// <summary>
    ///     The base font tag '&lt;basefont&gt;' sets a default font family, size, and color for the text in a document.
    /// </summary>
    public static Tag BaseFont { get; } = new ("basefont");

    /// <summary>
    ///     The bi-directional isolate tag '&lt;bdi&gt;' overrides the current directionality of text.
    /// </summary>
    public static Tag BiDirectionalIsolation { get; } = new ("bdi");

    /// <summary>
    ///     The bi-directional override tag '&lt;bdo&gt;' overrides the current directionality of text.
    /// </summary>
    public static Tag BiDirectionalOverride { get; } = new ("bdo");

    /// <summary>
    ///     The big tag '&lt;big&gt;' represents a span of text conventionally styled in a large font.
    /// </summary>
    public static Tag Big { get; } = new ("big");

    /// <summary>
    ///     The blockquote tag '&lt;blockquote&gt;' represents a section that is quoted from another source.
    /// </summary>
    public static Tag BlockQuote { get; } = new ("blockquote");

    /// <summary>
    ///     The bold tag '&lt;b&gt;' represents a span of text conventionally styled in bold.
    /// </summary>
    public static Tag Bold { get; } = new ("b");

    /// <summary>
    ///     The button tag '&lt;button&gt;' represents a clickable button.
    /// </summary>
    public static Tag Button { get; } = new ("button");

    /// <summary>
    ///     The canvas tag '&lt;canvas&gt;' represents a container for graphics.
    /// </summary>
    public static Tag Canvas { get; } = new ("canvas");

    /// <summary>
    ///     The center tag '&lt;center&gt;' represents a block of content that is centered horizontally.
    /// </summary>
    public static Tag Center { get; } = new ("center");

    /// <summary>
    ///     The cite tag '&lt;cite&gt;' represents a reference to a creative work, such as a book, a poem, a song, a movie, or a TV show.
    /// </summary>
    public static Tag Cite { get; } = new ("cite");

    /// <summary>
    ///     The code tag '&lt;code&gt;' represents a fragment of computer code.
    /// </summary>
    public static Tag Code { get; } = new ("code");

    /// <summary>
    ///     The column tag '&lt;col&gt;' represents a column in a table.
    /// </summary>
    public static Tag Column { get; } = new ("col");

    /// <summary>
    ///     The column group tag '&lt;colgroup&gt;' represents a group of one or more columns in a table.
    /// </summary>
    public static Tag ColumnGroup { get; } = new ("colgroup");

    /// <summary>
    ///     The command tag '&lt;command&gt;' represents a command that the user can invoke.
    /// </summary>
    public static Tag Command { get; } = new ("command");

    /// <summary>
    ///     The data list tag '&lt;datalist&gt;' represents a set of predefined options for other controls.
    /// </summary>
    public static Tag DataList { get; } = new ("datalist");

    /// <summary>
    ///     The definition tag '&lt;dfn&gt;' represents the defining instance of a term.
    /// </summary>
    public static Tag Definition { get; } = new ("dfn");

    /// <summary>
    ///     The definition description tag '&lt;dd&gt;' represents a description or value in a description list.
    /// </summary>
    public static Tag DefinitionDescription { get; } = new ("dd");

    /// <summary>
    ///     The definition list tag '&lt;dl&gt;' represents a description list.
    /// </summary>
    public static Tag DefinitionList { get; } = new ("dl");

    /// <summary>
    ///     The definition term tag '&lt;dt&gt;' represents a term (or name) in a description list.
    /// </summary>
    public static Tag DefinitionTerm { get; } = new ("dt");

    /// <summary>
    ///     The deleted tag '&lt;del&gt;' represents a range of text that has been deleted from a document.
    /// </summary>
    public static Tag DeletedText { get; } = new ("del");

    /// <summary>
    ///     The details tag '&lt;details&gt;' represents a disclosure widget from which the user can obtain additional information.
    /// </summary>
    public static Tag Details { get; } = new ("details");

    /// <summary>
    ///     The division tag '&lt;div&gt;' represents a generic flow container.
    /// </summary>
    public static Tag Div { get; } = new ("div");

    /// <summary>
    ///     The body tag '&lt;body&gt;' represents the content of an HTML document.
    /// </summary>
    public static Tag DocumentBody { get; } = new ("body");

    /// <summary>
    ///     The embed tag '&lt;embed&gt;' represents an integration point for an external application or interactive content.
    /// </summary>
    public static Tag Embed { get; } = new ("embed");

    /// <summary>
    ///     The emphasis tag '&lt;em&gt;' represents text with an emphasis, such as stress emphasis.
    /// </summary>
    public static Tag EmphaticStress { get; } = new ("em");

    /// <summary>
    ///     The object tag '&lt;object&gt;' represents an external resource, which can be treated as an image, a nested browsing context, or a resource to be handled by a plugin.
    /// </summary>
    public static Tag ExternalResource { get; } = new ("object");

    /// <summary>
    ///     The fieldset tag '&lt;fieldset&gt;' represents a set of form controls grouped together.
    /// </summary>
    public static Tag FieldSet { get; } = new ("fieldset");

    /// <summary>
    ///     The figure tag '&lt;figure&gt;' represents a self-contained composition in a document, page, application, or site.
    /// </summary>
    public static Tag Figure { get; } = new ("figure");

    /// <summary>
    ///     The figure caption tag '&lt;figcaption&gt;' represents a caption or legend for a figure.
    /// </summary>
    public static Tag FigureCaption { get; } = new ("figcaption");

    /// <summary>
    ///     The font tag '&lt;font&gt;' changes the font size, font face, and color of text.
    /// </summary>
    public static Tag Font { get; } = new ("font");

    /// <summary>
    ///     The footer tag '&lt;footer&gt;' represents a footer for a document, page, section, or article.
    /// </summary>
    public static Tag Footer { get; } = new ("footer");

    /// <summary>
    ///     The form tag '&lt;form&gt;' represents a section containing interactive controls for submitting information.
    /// </summary>
    public static Tag Form { get; } = new ("form");

    /// <summary>
    ///     The head tag '&lt;head&gt;' represents a container for metadata about an HTML document.
    /// </summary>
    public static Tag Head { get; } = new ("head");

    /// <summary>
    ///     The heading 1 tag '&lt;h1&gt;' represents a section heading of the highest rank.
    /// </summary>
    public static Tag Head1 { get; } = new ("h1");

    /// <summary>
    ///     The heading 2 tag '&lt;h2&gt;' represents a section heading of the second rank.
    /// </summary>
    public static Tag Head2 { get; } = new ("h2");

    /// <summary>
    ///     The heading 3 tag '&lt;h3&gt;' represents a section heading of the third rank.
    /// </summary>
    public static Tag Head3 { get; } = new ("h3");

    /// <summary>
    ///     The heading 4 tag '&lt;h4&gt;' represents a section heading of the fourth rank.
    /// </summary>
    public static Tag Head4 { get; } = new ("h4");

    /// <summary>
    ///     The heading 5 tag '&lt;h5&gt;' represents a section heading of the fifth rank.
    /// </summary>
    public static Tag Head5 { get; } = new ("h5");

    /// <summary>
    ///     The heading 6 tag '&lt;h6&gt;' represents a section heading of the sixth rank.
    /// </summary>
    public static Tag Head6 { get; } = new ("h6");

    /// <summary>
    ///     The header tag '&lt;header&gt;' represents a container for introductory content or a set of navigational links.
    /// </summary>
    public static Tag Header { get; } = new ("header");

    /// <summary>
    ///     The heading group tag '&lt;hgroup&gt;' represents a multi-level heading for a section of a document.
    /// </summary>
    public static Tag HeadGroup { get; } = new ("hgroup");

    /// <summary>
    ///     The horizontal rule tag '&lt;hr&gt;' represents a thematic break between paragraph-level elements.
    /// </summary>
    public static Tag HorizontalRule { get; } = new ("hr");

    /// <summary>
    ///     The HTML tag '&lt;html&gt;' represents the root element of an HTML document.
    /// </summary>
    public static Tag Html { get; } = new ("html");

    /// <summary>
    ///     The hyperlink tag '&lt;a&gt;' defines a hyperlink to a URL.
    /// </summary>
    public static Tag Hyperlink { get; } = new ("a");

    /// <summary>
    ///     The image tag '&lt;img&gt;' represents an image in an HTML document.
    /// </summary>
    public static Tag Image { get; } = new ("img");

    /// <summary>
    ///     The image map tag '&lt;map&gt;' represents a client-side image map.
    /// </summary>
    public static Tag ImageMap { get; } = new ("map");

    /// <summary>
    ///     The inline frame tag '&lt;iframe&gt;' represents a nested browsing context.
    /// </summary>
    public static Tag InlineFrame { get; } = new ("iframe");

    /// <summary>
    ///     The input tag '&lt;input&gt;' represents an interactive control within a form.
    /// </summary>
    public static Tag Input { get; } = new ("input");

    /// <summary>
    ///     The inserted tag '&lt;ins&gt;' represents a range of text that has been added to a document.
    /// </summary>
    public static Tag InsertedText { get; } = new ("ins");

    /// <summary>
    ///     The italic tag '&lt;i&gt;' represents a span of text conventionally styled in italic.
    /// </summary>
    public static Tag Italic { get; } = new ("i");

    /// <summary>
    ///     The keyboard input tag '&lt;kbd&gt;' represents user input, typically entered via the keyboard.
    /// </summary>
    public static Tag KeyboardInput { get; } = new ("kbd");

    /// <summary>
    ///     The key-pair generator/input control tag '&lt;keygen&gt;' represents a control for generating a key pair, which can be submitted with a form and used for client-side cryptographic purposes.
    /// </summary>
    public static Tag KeyPairGenerator { get; } = new ("keygen");

    /// <summary>
    ///     The label tag '&lt;label&gt;' represents a caption for a user interface control in a web form.
    /// </summary>
    public static Tag Label { get; } = new ("label");

    /// <summary>
    ///     The legend tag '&lt;legend&gt;' represents a caption for the content of a fieldset element.
    /// </summary>
    public static Tag Legend { get; } = new ("legend");

    /// <summary>
    ///     The line break tag '&lt;br&gt;' represents a line break.
    /// </summary>
    public static Tag LineBreak { get; } = new ("br");

    /// <summary>
    ///     The link tag '&lt;link&gt;' defines a link between a document and an external resource.
    /// </summary>
    public static Tag Link { get; } = new ("link");

    /// <summary>
    ///     The list item tag '&lt;li&gt;' represents a list item.
    /// </summary>
    public static Tag ListItem { get; } = new ("li");

    /// <summary>
    ///     The mark tag '&lt;mark&gt;' represents highlighted text.
    /// </summary>
    public static Tag Mark { get; } = new ("mark");

    /// <summary>
    ///     The MathML tag '&lt;math&gt;' represents mathematical content, used for displaying mathematical formulas and equations.
    /// </summary>
    public static Tag Math { get; } = new ("math");

    /// <summary>
    ///     The menu tag '&lt;menu&gt;' represents a list of commands.
    /// </summary>
    public static Tag Menu { get; } = new ("menu");

    /// <summary>
    ///     The meta tag '&lt;meta&gt;' represents metadata that cannot be represented by other HTML meta-related elements.
    /// </summary>
    public static Tag Meta { get; } = new ("meta");

    /// <summary>
    ///     The meter tag '&lt;meter&gt;' represents a scalar measurement or a fractional value within a known range.
    /// </summary>
    public static Tag Meter { get; } = new ("meter");

    /// <summary>
    ///     The navigation tag '&lt;nav&gt;' represents a section of a page that contains navigation links.
    /// </summary>
    public static Tag Navigation { get; } = new ("nav");

    /// <summary>
    ///     The no-script tag '&lt;noscript&gt;' represents fallback content that is displayed when JavaScript is not supported or enabled in the browser.
    /// </summary>
    public static Tag NoScript { get; } = new ("noscript");

    /// <summary>
    ///     The option tag '&lt;option&gt;' represents an option in a select element or a list of suggestions in a datalist element.
    /// </summary>
    public static Tag Option { get; } = new ("option");

    /// <summary>
    ///     The option group tag '&lt;optgroup&gt;' represents a group of options within a select element.
    /// </summary>
    public static Tag OptionGroup { get; } = new ("optgroup");

    /// <summary>
    ///     The ordered list tag '&lt;ol&gt;' represents an ordered list of items.
    /// </summary>
    public static Tag OrderedList { get; } = new ("ol");

    /// <summary>
    ///     The output tag '&lt;output&gt;' represents the result of a calculation or user action.
    /// </summary>
    public static Tag Output { get; } = new ("output");

    /// <summary>
    ///     The paragraph tag '&lt;p&gt;' represents a paragraph of text.
    /// </summary>
    public static Tag Paragraph { get; } = new ("p");

    /// <summary>
    ///     The parameter tag '&lt;param&gt;' represents a parameter for an object element.
    /// </summary>
    public static Tag Parameter { get; } = new ("param");

    /// <summary>
    ///     The preformatted text tag '&lt;pre&gt;' represents preformatted text.
    /// </summary>
    public static Tag PreformattedText { get; } = new ("pre");

    /// <summary>
    ///     The progress tag '&lt;progress&gt;' represents the completion progress of a task.
    /// </summary>
    public static Tag Progress { get; } = new ("progress");

    /// <summary>
    ///     The quoted text tag '&lt;q&gt;' represents a short quotation.
    /// </summary>
    public static Tag QuotedText { get; } = new ("q");

    /// <summary>
    ///     The ruby annotation tag '&lt;ruby&gt;' represents a ruby annotation, which is a pronunciation or translation of foreign text.
    /// </summary>
    public static Tag RubyAnnotation { get; } = new ("ruby");

    /// <summary>
    ///     The ruby parenthesis tag '&lt;rp&gt;' represents the opening or closing parenthesis of a ruby annotation.
    /// </summary>
    public static Tag RubyParenthesis { get; } = new ("rp");

    /// <summary>
    ///     The ruby text tag '&lt;rt&gt;' represents the text component of a ruby annotation.
    /// </summary>
    public static Tag RubyText { get; } = new ("rt");

    /// <summary>
    ///     The sample output tag '&lt;samp&gt;' represents sample (or program) output.
    /// </summary>
    public static Tag Sample { get; } = new ("samp");

    /// <summary>
    ///     The script tag '&lt;script&gt;' represents embedded script content or a link to an external script file.
    /// </summary>
    public static Tag Script { get; } = new ("script");

    /// <summary>
    ///     The section tag '&lt;section&gt;' represents a standalone section that is part of a larger document or application.
    /// </summary>
    public static Tag Section { get; } = new ("section");

    /// <summary>
    ///     The select tag '&lt;select&gt;' represents a control for selecting one or more options from a list of choices.
    /// </summary>
    public static Tag Select { get; } = new ("select");

    /// <summary>
    ///     The small tag '&lt;small&gt;' represents small print.
    /// </summary>
    public static Tag Small { get; } = new ("small");

    /// <summary>
    ///     The source tag '&lt;source&gt;' specifies multiple media resources for media elements, such as &lt;video&gt; and &lt;audio&gt;.
    /// </summary>
    public static Tag Source { get; } = new ("source");

    /// <summary>
    ///     The span tag '&lt;span&gt;' represents a generic span for inline elements.
    /// </summary>
    public static Tag Span { get; } = new ("span");

    /// <summary>
    ///     The strike tag '&lt;strike&gt;' represents a span of text that is no longer accurate or relevant.
    /// </summary>
    public static Tag Strike { get; } = new ("strike");

    /// <summary>
    ///     The strong tag '&lt;strong&gt;' represents text of strong importance.
    /// </summary>
    public static Tag Strong { get; } = new ("strong");

    /// <summary>
    ///     The struck text tag '&lt;s&gt;' represents text that is no longer accurate or relevant.
    /// </summary>
    public static Tag Struck { get; } = new ("s");

    /// <summary>
    ///     The style tag '&lt;style&gt;' represents style (presentation) information for an HTML document.
    /// </summary>
    public static Tag Style { get; } = new ("style");

    /// <summary>
    ///     The subscript tag '&lt;sub&gt;' represents subscript text.
    /// </summary>
    public static Tag Subscript { get; } = new ("sub");

    /// <summary>
    ///     The summary tag '&lt;summary&gt;' represents a summary, caption, or legend for a details control.
    /// </summary>
    public static Tag Summary { get; } = new ("summary");

    /// <summary>
    ///     The superscript tag '&lt;sup&gt;' represents superscript text.
    /// </summary>
    public static Tag Superscript { get; } = new ("sup");

    /// <summary>
    ///     The SVG tag '&lt;svg&gt;' represents scalable vector graphics, used for defining graphics and animations in XML format.
    /// </summary>
    public static Tag Svg { get; } = new ("svg");

    /// <summary>
    ///     The table tag '&lt;table&gt;' represents a table of data.
    /// </summary>
    public static Tag Table { get; } = new ("table");

    /// <summary>
    ///     The table body tag '&lt;tbody&gt;' represents a group of rows in a table.
    /// </summary>
    public static Tag TableBody { get; } = new ("tbody");

    /// <summary>
    ///     The caption tag '&lt;caption&gt;' represents the title of a table.
    /// </summary>
    public static Tag TableCaption { get; } = new ("caption");

    /// <summary>
    ///     The table cell tag '&lt;td&gt;' represents a cell in a table.
    /// </summary>
    public static Tag TableCell { get; } = new ("td");

    /// <summary>
    ///     The table footer tag '&lt;tfoot&gt;' represents a group of footer rows in a table.
    /// </summary>
    public static Tag TableFooter { get; } = new ("tfoot");

    /// <summary>
    ///     The table header tag '&lt;thead&gt;' represents a group of header rows in a table.
    /// </summary>
    public static Tag TableHeader { get; } = new ("thead");

    /// <summary>
    ///     The table header cell tag '&lt;th&gt;' represents a header cell in a table.
    /// </summary>
    public static Tag TableHeaderCell { get; } = new ("th");

    /// <summary>
    ///     The table row tag '&lt;tr&gt;' represents a row in a table.
    /// </summary>
    public static Tag TableRow { get; } = new ("tr");

    /// <summary>
    ///     The aside tag '&lt;aside&gt;' represents content that is separate from the main content and can be considered independent or unrelated.
    /// </summary>
    public static Tag TangentialContent { get; } = new ("aside");

    /// <summary>
    ///     The tt tag '&lt;tt&gt;' represents a span of text that should be rendered in a monospaced font.
    /// </summary>
    public static Tag TeletypeText { get; } = new ("tt");

    /// <summary>
    ///     The text area tag '&lt;textarea&gt;' represents a multi-line plain-text editing control.
    /// </summary>
    public static Tag TextArea { get; } = new ("textarea");

    /// <summary>
    ///     The time tag '&lt;time&gt;' represents a specific period in time or a range of times.
    /// </summary>
    public static Tag Time { get; } = new ("time");

    /// <summary>
    ///     The title tag '&lt;title&gt;' represents the title of an HTML document.
    /// </summary>
    public static Tag Title { get; } = new ("title");

    /// <summary>
    ///     The track tag '&lt;track&gt;' represents a text track for media elements, such as &lt;video&gt; and &lt;audio&gt;.
    /// </summary>
    public static Tag Track { get; } = new ("track");

    /// <summary>
    ///     The underline tag '&lt;u&gt;' represents a span of text conventionally styled with an underline.
    /// </summary>
    public static Tag Underline { get; } = new ("u");

    /// <summary>
    ///     The unordered list tag '&lt;ul&gt;' represents an unordered list of items.
    /// </summary>
    public static Tag UnorderedList { get; } = new ("ul");

    /// <summary>
    ///     The variable tag '&lt;var&gt;' represents the name of a variable in mathematical expressions or programming contexts.
    /// </summary>
    public static Tag Variable { get; } = new ("var");

    /// <summary>
    ///     The video tag '&lt;video&gt;' represents a video or movie.
    /// </summary>
    public static Tag Video { get; } = new ("video");

    /// <summary>
    ///     The word break opportunity tag '&lt;wbr&gt;' represents a position within text where the browser may optionally break a line.
    /// </summary>
    public static Tag WordBreak { get; } = new ("wbr");

    /// <summary>
    ///     The XML namespace tag '&lt;xml&gt;' represents the XML namespace.
    /// </summary>
    public static Tag XmlNamespace { get; } = new ("xml");
}