import { HttpEventType, HttpProgressEvent, HttpResponse } from '@angular/common/http';
import { Component, ChangeDetectionStrategy, Input, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import { Photo } from '../../member.model';
import { MemberService } from '../../services/member.service';

@Component({
    selector: 'da-photo-editor',
    templateUrl: './photo-editor.component.html',
    styleUrls: ['./photo-editor.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class PhotoEditorComponent implements OnDestroy {
    @Input()
    public photos: Photo[] = [];

    public uploadingProgress: number | null = null;

    private destroy$ = new Subject<void>();

    constructor(private readonly memberService: MemberService,
        private readonly cdr: ChangeDetectorRef) {
    }

    public ngOnDestroy(): void {
        this.destroy$.next();
        this.destroy$.complete();
    }

    public onFileInputChange(e: Event){
        this.uploadingProgress = 0;
        const fileList = (e.target as HTMLInputElement).files;
        console.log(fileList);
        const file = fileList![0];

        this.memberService.addPhoto(file)
            .pipe(
                takeUntil(this.destroy$),
                finalize(() => {
                    this.uploadingProgress = null;
                })
            )
            .subscribe(loadEvent => this.processLoadEvent(loadEvent));
    }

    private processLoadEvent(e: HttpProgressEvent | HttpResponse<Photo>) {
        if (e.type === HttpEventType.UploadProgress) {
            this.uploadingProgress = Math.round(e.loaded * 100 / e.total!);
        } else {
            const result = e as HttpResponse<Photo>;
            if (result.body) {
                this.photos.push(result.body);
            }
        }
        this.cdr.markForCheck();
    }
}
