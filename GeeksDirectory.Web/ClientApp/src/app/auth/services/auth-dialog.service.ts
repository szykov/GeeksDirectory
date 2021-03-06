import { Injectable } from '@angular/core';
import { ComponentType } from '@angular/cdk/portal';

import { Observable, merge } from 'rxjs';
import { mapTo, filter } from 'rxjs/operators';

import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { CredentialsModel, ISignDialogResult } from '@app/auth/models';
import { DialogChoice } from '@shared/common';
import { SignInDialogComponent } from '@app/auth/components';

@Injectable({
	providedIn: 'root'
})
export class AuthDialogService {
	constructor(private dialog: MatDialog) {}

	public signIn(model?: CredentialsModel): Observable<ISignDialogResult> {
		return this.baseDialog(SignInDialogComponent, { height: '300px', width: '400px', data: model });
	}

	private baseDialog(component: ComponentType<unknown>, config: MatDialogConfig): Observable<ISignDialogResult> {
		const dialogRef = this.dialog.open(component, config);
		let backDrop$ = dialogRef.backdropClick().pipe(mapTo({ choice: DialogChoice.Canceled }));

		return merge(dialogRef.afterClosed(), backDrop$).pipe(filter((result) => !!result));
	}
}
