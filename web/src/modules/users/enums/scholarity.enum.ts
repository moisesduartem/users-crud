export enum Scholarity {
    Primary = 0,
    Elementary = 1,
    HighSchool = 2,
    University = 3
}

export const SCHOLARITY_NAMES = {
    [Scholarity.Primary]: 'Infantil',
    [Scholarity.Elementary]: 'Fundamental',
    [Scholarity.HighSchool]: 'Ens. Médio',
    [Scholarity.University]: 'Ens. Superior'
}