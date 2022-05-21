import {ArgumentElementException} from "./exceptions.mjs";

export class HtmlElement
{
    static blur(element: HTMLElement)
    {
        ArgumentElementException.throwWhenNotDomElement(element, "element");

        element.blur();
    }
}