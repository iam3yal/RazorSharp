import {ArgumentNullException, ArgumentOutOfRangeException} from "./exceptions.mjs";

export class EventDebouncer {
    #timerHandle: number = -1

    static createInstance() {
        return new EventDebouncer()
    }

    async debounce(delegate: any, interval: number) {
        ArgumentNullException.throwWhenNullOrUndefined(delegate, "delegate")
        ArgumentOutOfRangeException.throwWhenNegative(interval, "interval")

        if (this.#timerHandle > 0) {
            clearTimeout(this.#timerHandle);
            this.#timerHandle = -1
        }

        this.#timerHandle = setTimeout(async () => {
            try {
                await delegate.func.invokeMethodAsync("InvokeAsync")
            } finally {
                delegate.func.dispose()
            }
        }, interval)
    }
}

