interface ICustomerReportData {
    customerId: number | null,
    unvan: string | null,
    addressId: number | null,
    sehir: string | null,
    ilce: string | null,
    semt: string | null,
    deviceId: number | null,
    tip: string | null,
    marka: string | null,
    model: string | null,
    cihazSeriNo: string | null,
    montajTarihi: string | null,
    sozlesmeKodu: string | null,
    baslangicTarihi: string | null,
    bitisTarihi: string | null,
}

export { ICustomerReportData };