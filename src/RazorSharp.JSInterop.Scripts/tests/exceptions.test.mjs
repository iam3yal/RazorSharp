"use strict";

import {describe, expect, test} from "@jest/globals";
import {JSDOM} from "jsdom";

import {
    ArgumentElementException,
    ArgumentEmptyException,
    ArgumentException,
    ArgumentNullException
} from "wwwroot/exceptions.mjs";

describe("ArgumentException", () => {
    test("should create an instance of ArgumentException", () => {
        expect(new ArgumentException("msg"))
            .toBeInstanceOf(ArgumentException);
    });

    describe("throwWhenFalsy", () => {
        test.each`
          value         | falsy
          ${false}      | ${"false"}
          ${0}          | ${"zero"}
          ${-0}         | ${"minus-zero"}
          ${""}         | ${"empty double-quote"}
          ${""}         | ${"empty single-quote"}
          ${``}         | ${"empty back-quote"}
          ${null}       | ${"null"}
          ${undefined}  | ${"undefined"}
          ${NaN}        | ${"not a number"}
          `("should throw when value is $falsy", ({value}) => {
            expect(() => ArgumentException.throwWhenFalsy(value, "paramName"))
                .toThrow(ArgumentException);
        });

        test.each`
          value         | truthy
          ${true}       | ${"true"}
          ${1}          | ${"positive number"}
          ${-1}         | ${"negative number"}
          ${"0"}        | ${"non-empty double-quote"}
          ${"1"}        | ${"non-empty single-quote"}
          ${`3`}        | ${"non-empty back-quote"}
          ${[]}         | ${"array"}
          ${{}}         | ${"object"}
          `("should not throw when value is $truthy", ({value}) => {
            expect(() => ArgumentException.throwWhenFalsy(value, "paramName"))
                .not
                .toThrow(ArgumentException);
        });
    });
});

describe("ArgumentNullException", () => {
    test("should create an instance of ArgumentNullException", () => {
        expect(new ArgumentNullException("msg"))
            .toBeInstanceOf(ArgumentNullException);
    });

    describe("throwWhenNullOrUndefined", () => {
        test.each`
          value         | $invalid
          ${null}       | ${"null"}
          ${undefined}  | ${"undefined"}
          `("should throw when value is $invalid", ({value}) => {
            expect(() => ArgumentNullException.throwWhenNullOrUndefined(value, "paramName"))
                .toThrow(ArgumentNullException);
        });

        test("should not throw when value is non-empty string", () => {
            expect(() => ArgumentNullException.throwWhenNullOrUndefined("foo", "paramName"))
                .not
                .toThrow(ArgumentNullException);
        });
    });
});

describe("ArgumentEmptyException", () => {
    test("should create an instance of ArgumentNullException", () => {
        expect(new ArgumentEmptyException("msg"))
            .toBeInstanceOf(ArgumentEmptyException);
    });

    describe("throwWhenEmpty", () => {
        test.each`
          value     | $invalid
          ${[]}     | ${"empty array"}
          ${""}     | ${"empty double-quote"} 
          `("should throw when value is $invalid", ({value}) => {
            expect(() => ArgumentEmptyException.throwWhenEmpty(value, "paramName"))
                .toThrow(ArgumentEmptyException);
        });

        test.each`
          value     | valid
          ${[1]}    | ${"non-empty array"}
          ${"2"}    | ${"non-empty double-quote"}
          `("should not throw when value is $valid", ({value}) => {
            expect(() => ArgumentEmptyException.throwWhenEmpty(value, "paramName"))
                .not
                .toThrow(ArgumentEmptyException);
        });
    });
});

describe("ArgumentElementException", () => {
    test("should create an instance of ArgumentNullException", () => {
        expect(new ArgumentElementException("msg"))
            .toBeInstanceOf(ArgumentElementException);
    });

    describe("throwWhenNotDomElement", () => {
        test("should throw when value is not dom element", () => {
            expect(() => {
                const dom = new JSDOM(`<body></body>`);
                const comment = dom.window.document.createComment("comment");

                ArgumentElementException.throwWhenNotDomElement(comment, "paramName");
            })
                .toThrow(ArgumentElementException);
        });

        test("should not throw when value is dom element", () => {
            expect(() => {
                const dom = new JSDOM(`<body></body>`);
                const paragraph = dom.window.document.createElement("p");

                ArgumentElementException.throwWhenNotDomElement(paragraph, "paramName");
            })
                .not
                .toThrow(ArgumentElementException);
        });
    });
});