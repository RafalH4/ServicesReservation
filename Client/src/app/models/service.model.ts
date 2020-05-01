export interface ServiceDto{
    id: string;
    serviceName: string;
    date: Date;
    dateOfReservation: Date;
    providerFullName: string;
    ClientFullName: string;
    Advance: number;
    LeftToPay: number;
}