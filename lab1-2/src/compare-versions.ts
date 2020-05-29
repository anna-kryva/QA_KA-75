export const compareVersions = (v1: string, v2: string): number => {
    const v1Splitted = v1.split('.').map(el => +el)
    const v2Splitted = v2.split('.').map(el => +el)
    const longestV = v1Splitted.length > v2Splitted.length ? v1Splitted : v2Splitted
    let result = 0
    for (let idx = 0; idx < longestV.length; idx++) {
        const v1Value = v1Splitted[idx]
        const v2Value = v2Splitted[idx]
        if (v1Value && v2Value) {
            if (v1Value !== v2Value) {
                result = v1Value > v2Value ? 1 : -1
                break;
            }
        } else if (v1Value > 0) {
            result = 1
            break
        } else if (v2Value > 0) {
            result = -1
            break
        }
    }
    return result
}



