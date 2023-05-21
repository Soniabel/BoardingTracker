export class Candidate {
    public firstName: string | null = null;
    public lastName: string | null = null;
    public phoneNumber: string | null = null;
    public profileImageUrl: string | null = null;
    public biography: string | null = null;
    public resumeUrl: string | null = null;
    public email: string | null = null;
    userId: string | null = null;

    constructor(
        firstName: string,
        lastName: string,
        phoneNumber: string,
        biography: string,
        profileImageUrl: string,
        resumeUrl: string,
        email: string,
        userId: string) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.phoneNumber = phoneNumber;
    this.biography = biography;
    this.profileImageUrl = profileImageUrl;
    this.resumeUrl = resumeUrl;
    this.email = email;
    this.userId = userId;
}

}