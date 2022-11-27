import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class TableService {
    private readonly _shouldReload = new BehaviorSubject<boolean>(false);

    readonly shouldReload$ = this._shouldReload.asObservable();

    private set shouldReload(value: boolean) {
        this._shouldReload.next(value);
    }

    get shouldReload(): boolean {
        return this._shouldReload.getValue();
    }

    updateValue(value: boolean) {
        this.shouldReload = value;
    }
}