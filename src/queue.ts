export interface Queue {
    count: number

    enqueue(element: any): number

    dequeue(): any

    clear(): void

    peek(): any
}

export class QueueImpl implements Queue{
    private _queue: Array<any>
    constructor(...args) {
        this._queue = args
    }

    get count(): number{
        return this._queue.length
    }
    clear(): void {
        this._queue.length = 0
    }

    dequeue(): any {
        return this._queue.shift()
    }

    enqueue(element: any): number {
        return this._queue.push(element)
    }

    peek(): any {
        return this._queue[0]
    }


}
