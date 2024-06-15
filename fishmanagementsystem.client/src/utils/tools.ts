// 文件名：@/utils/tool.ts
/**
 * localStorage设置有效期
 * @param name localStorage设置名称
 * @param data 数据对象
 * @param pExpires 有效期(默认100年)
 */
 export function setLocal(name:string, data:IObject<any>, pExpires = 1000 * 60 * 60 * 24 * 365 * 100):void {
  data.startTime = Date.now()
  data.expires = pExpires
  localStorage.setItem(name, JSON.stringify(data))
}

/**
 * 判断localStorage有效期是否失效
 * @param name localStorage设置名称
 */
 export async function useLocal(name: string):Promise<ILocalStore> {
    return new Promise((resolve, reject) => {
        const local = getLocal<ILocalStore>(name)
        if(local.startTime + local.expires < Date.now()) reject(`${name}已超过有效期`)
        resolve(local)
    })
}

/**
 * 二次编码url
 * @param url 
 * @returns 
 */
 export function decode(url: string): string {
    return decodeURIComponent(decodeURIComponent(url))
}

/**
 * 二次解码url
 * @param url 
 * @returns 
 */
export function encode(url: string): string {
    return encodeURIComponent(encodeURIComponent(url))
}
