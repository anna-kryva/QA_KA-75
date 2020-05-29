import {QueueImpl} from "./queue";

describe("queue should work as expected", () => {

    const queue = new QueueImpl(1, 2, 534, 345, 1, 3)
    test("check init queue length", () => {
        expect(queue.count).toBe(6)
    })
    test("check init peek", () => {
        expect(queue.peek()).toBe(1)
    })
    test("check peek after dequeue", () => {
        queue.dequeue()
        expect(queue.peek()).toBe(2)
    })
    test("check queue length after clear", () => {
        queue.clear()
        expect(queue.count).toBe(0)
    })
    test("check peek after enqueue", () => {
        queue.enqueue(228)
        expect(queue.peek()).toBe(228)
    })

})
