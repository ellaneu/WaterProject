import { getFingerprint } from '@thumbmarkjs/thumbmarkjs';
import { useEffect, useState } from 'react';

export const FingerPrint = () => {

    const [fingerPrint, setFingerPrint] = useState<string | null>(null)

    useEffect(() => {
        getFingerprint().then((fingerPrint) => setFingerPrint(fingerPrint))
    }, [])

    return <div>{fingerPrint}</div>
}



export default FingerPrint;