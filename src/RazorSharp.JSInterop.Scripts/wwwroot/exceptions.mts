"use strict";

export class ArgumentException extends Error {
    constructor(message: string) {
        super(message);

        Object.setPrototypeOf(this, new.target.prototype);

        this.name = this.constructor.name;
    }

    static throwWhenFalsy(paramValue: unknown, paramName: string) {
        if (!paramValue) {
            throw new ArgumentException(`The parameter '${paramName}' is falsy.`);
        }
    }
}

export class ArgumentNullException extends ArgumentException {
    static throwWhenNullOrUndefined(paramValue: unknown, paramName: string) {
        if (paramValue === null || paramValue === undefined) {
            throw new ArgumentNullException(`The parameter '${paramName}' is null or undefined.`);
        }
    }
}

export class ArgumentEmptyException extends ArgumentException {
    static throwWhenEmpty(paramValue: string | [], paramName: string) {
        ArgumentNullException.throwWhenNullOrUndefined(paramValue, paramName);

        if (paramValue.length === 0) {
            throw new ArgumentEmptyException(`The parameter '${paramName}' is empty.`);
        }
    }
}

export class ArgumentOutOfRangeException extends ArgumentException {
    static throwWhenNegative(paramValue: number, paramName: string) {
        ArgumentNullException.throwWhenNullOrUndefined(paramValue, paramName);

        if (paramValue < 0) {
            throw new ArgumentOutOfRangeException(`The parameter '${paramName}' is a negative value.`);
        }
    }
}

export class ArgumentElementException extends ArgumentException {
    static throwWhenNotDomElement(paramValue: HTMLElement, paramName: string) {
        ArgumentNullException.throwWhenNullOrUndefined(paramValue, paramName);

        if (!paramValue.nodeType || paramValue.nodeType !== 1) {
            throw new ArgumentElementException(`The parameter '${paramName}' is not a DOM element.`);
        }
    }
}