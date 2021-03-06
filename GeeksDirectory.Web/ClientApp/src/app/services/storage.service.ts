import { Injectable, Inject } from '@angular/core';

import { SESSION_STORAGE, isStorageAvailable, StorageService as NgxStorageService } from 'ngx-webstorage-service';
import { CookieService } from 'ngx-cookie-service';

import { IProfile } from '@app/responses';
import { IToken } from '@app/auth/responses';
import { CONFIG } from '@shared/config';

@Injectable({
	providedIn: 'root'
})
export class StorageService {
	constructor(private cookieService: CookieService, @Inject(SESSION_STORAGE) private storage: NgxStorageService) {
		if (!isStorageAvailable(sessionStorage)) {
			throw new Error('Your browser do not support Local Storage');
		}
	}

	public setAuthToken(token: IToken): void {
		let expiredDate = new Date();
		expiredDate.setDate(Date.now());
		expiredDate.setSeconds(expiredDate.getSeconds() + token.expires_in);

		this.cookieService.set(`${CONFIG.prefix}-token`, JSON.stringify(token), expiredDate, '/', null, null, 'Strict');
	}

	public getAuthToken(): IToken {
		let token = this.cookieService.get(`${CONFIG.prefix}-token`);
		return JSON.parse(token);
	}

	public existsAuthToken(): boolean {
		return this.cookieService.check(`${CONFIG.prefix}-token`);
	}

	public clearAuthToken(): void {
		this.cookieService.delete(`${CONFIG.prefix}-token`, '/');
	}

	public setAuthUser(profile: IProfile): void {
		this.storage.set(`${CONFIG.prefix}-profile`, profile);
	}

	public getAuthUser(): IProfile {
		return this.storage.get(`${CONFIG.prefix}-profile`);
	}

	public clearAuthUser(): void {
		this.storage.remove(`${CONFIG.prefix}-profile`);
	}

	public existsAuthUser(): boolean {
		return this.storage.has(`${CONFIG.prefix}-profile`);
	}
}
