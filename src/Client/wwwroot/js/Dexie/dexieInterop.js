class DexieService {
    constructor(databaseName) {
        this.db = new Dexie(databaseName);
    }

    initialize() {
        this.db.version(1).stores({
            chatConversations: '++id, title, timestamp, code, deleted',
            textMessages: '++id, conversationId, message, timestamp, isCopyable, FromUserId, ExpiryMinutes, AllowedViewCount',
            audioMessages: '++id, conversationId, audioUrl, timestamp, lengthInSeconds, FromUserId, ExpiryMinutes, AllowedViewCount',
            imageMessages: '++id, conversationId, imageUrl, timestamp, name, width, height, sizeInKB, FromUserId, ExpiryMinutes, AllowedViewCount',
            fileMessages: '++id, conversationId, filePath, canBeDownloaded, name, width, height, sizeInKB, extension, FromUserId, ExpiryMinutes, AllowedViewCount',
            locationMessages: '++id, conversationId, latitude, longitude, timestamp, FromUserId, ExpiryMinutes, AllowedViewCount',
            conversationEntries: '[conversationId+timestamp], messageId, messageType',
            settings: '++id, name, value',
            chatConversationSettings: '++id, conversationId, settingId, value'
        });

        // Check if settings table is empty
        this.db.settings.count().then(count => {
            if (count === 0) {
                // Settings table is empty, add default settings
                this.db.settings.bulkAdd([
                    { name: 'language', value: 'en' },
                    { name: 'theme', value: 'dark' },

                ]);
            }
        });
        let demoAudioUrl = 'https://freetestdata.com/wp-content/uploads/2021/09/Free_Test_Data_100KB_MP3.mp3';
        let demoImageUrl = 'https://freetestdata.com/wp-content/uploads/2022/02/Free_Test_Data_117KB_JPG.jpg';
        let demoPdfUrl = 'https://freetestdata.com/wp-content/uploads/2021/09/Free_Test_Data_100KB_PDF.pdf';
        // Check if chatConversations table is empty
        this.db.chatConversations.count().then(count => {
            if (count === 0) {
                // chatConversations table is empty, add a demo conversation
                this.db.chatConversations.add({ title: 'Demo Conversation', timestamp: Date.now(), code: 123654897, deleted: false }).then(id => {
                    // Then add some demo messages for this conversation
                    //let demoMessages = [
                    //    { id: 1, conversationId: id, message: 'Hello, this is a demo text message.', timestamp: Date.now(), isCopyable: true, messageType: 'text' },
                    //    { id: 2, conversationId: id, audioUrl: demoAudioUrl, timestamp: Date.now() + 1000, lengthInSeconds: 120, messageType: 'audio' },
                    //    { id: 3, conversationId: id, imageUrl: demoImageUrl, name: 'demo-image', width: 1024, height: 768, sizeInKB: 500, timestamp: Date.now() + 2000, messageType: 'image' },
                    //    { id: 4, conversationId: id, filePath: demoPdfUrl, canBeDownloaded: true, name: 'demo-file', width: 1024, height: 768, sizeInKB: 200, extension: '.pdf', timestamp: Date.now() + 3000, messageType: 'file' },
                    //    { id: 5, conversationId: id, latitude: 40.712776, longitude: -74.005974, timestamp: Date.now() + 4000, messageType: 'location' },
                    //    { id: 6, conversationId: id, message: '22 Hello, this is a demo text message.', timestamp: Date.now(), isCopyable: true, messageType: 'text' 
                    //];


                    let demoMessages = [
                        { id: 1, conversationId: id, message: 'Hello, this is your bank. How may I assist you today?', timestamp: Date.now(), isCopyable: true, messageType: 'text', FromUserId: 'bank-employee', ExpiryMinutes: 30, AllowedViewCount: 5 },
                        { id: 2, conversationId: id, message: 'I need help with my account balance.', timestamp: Date.now() + 1000, isCopyable: true, messageType: 'text', FromUserId: '30106c2a-acb3-4b75-8550-8f6279af9567', ExpiryMinutes: 30, AllowedViewCount: 5 },
                        { id: 3, conversationId: id, filePath: demoPdfUrl, canBeDownloaded: true, name: 'Account-Statement', width: 1024, height: 768, sizeInKB: 200, extension: '.pdf', timestamp: Date.now() + 2000, messageType: 'file', FromUserId: 'bank-employee', ExpiryMinutes: 30, AllowedViewCount: 5 },
                        { id: 4, conversationId: id, message: 'Here is your account statement. Do you need anything else?', timestamp: Date.now() + 3000, isCopyable: true, messageType: 'text', FromUserId: 'bank-employee', ExpiryMinutes: 30, AllowedViewCount: 5 },
                        { id: 5, conversationId: id, message: 'Can you explain the last transaction to me?', timestamp: Date.now() + 4000, isCopyable: true, messageType: 'text', FromUserId: '30106c2a-acb3-4b75-8550-8f6279af9567', ExpiryMinutes: 30, AllowedViewCount: 5 },
                        { id: 6, conversationId: id, message: 'Certainly! The last transaction was a withdrawal from ATM #1234 located at Main Street.', timestamp: Date.now() + 5000, isCopyable: true, messageType: 'text', FromUserId: 'bank-employee', ExpiryMinutes: 30, AllowedViewCount: 5 },
                        { id: 7, conversationId: id, latitude: 40.712776, longitude: -74.005974, timestamp: Date.now() + 6000, messageType: 'location', FromUserId: 'bank-employee', ExpiryMinutes: 30, AllowedViewCount: 5 },
                        { id: 8, conversationId: id, audioUrl: demoAudioUrl, timestamp: Date.now() + 7000, lengthInSeconds: 120, messageType: 'audio', FromUserId: '30106c2a-acb3-4b75-8550-8f6279af9567', ExpiryMinutes: 30, AllowedViewCount: 5 },
                        { id: 9, conversationId: id, imageUrl: demoImageUrl, name: 'Transaction-Receipt', width: 1024, height: 768, sizeInKB: 500, timestamp: Date.now() + 8000, messageType: 'image', FromUserId: 'bank-employee', ExpiryMinutes: 30, AllowedViewCount: 5 },
                        { id: 10, conversationId: id, message: 'Here is an image of the transaction receipt. Is there anything else?', timestamp: Date.now() + 9000, isCopyable: true, messageType: 'text', FromUserId: 'bank-employee', ExpiryMinutes: 30, AllowedViewCount: 5 },
                        { id: 11, conversationId: id, message: 'No, thank you for your help!', timestamp: Date.now() + 10000, isCopyable: true, messageType: 'text', FromUserId: '30106c2a-acb3-4b75-8550-8f6279af9567', ExpiryMinutes: 30, AllowedViewCount: 5 }
                    ];
                    

                    // Add messages to their respective tables and conversationEntries table
                    demoMessages.forEach(msg => {
                        let table;
                        switch (msg.messageType) {
                            case 'text':
                                table = this.db.textMessages;
                                break;
                            case 'audio':
                                table = this.db.audioMessages;
                                break;
                            case 'image':
                                table = this.db.imageMessages;
                                break;
                            case 'file':
                                table = this.db.fileMessages;
                                break;
                            case 'location':
                                table = this.db.locationMessages;
                                break;
                            default:
                                console.error(`Unsupported message type: ${msg.messageType}`);
                                break;
                        }

                        table.add(msg).then(messageId => {
                            this.db.conversationEntries.add({
                                conversationId: msg.conversationId,
                                messageId: messageId,
                                timestamp: msg.timestamp,
                                messageType: msg.messageType
                            });
                        });
                    });
                });
            }
        });

    }

    // Helper function to perform a database operation and log any errors
    dbOperation(operation) {
        return operation.catch(err => {
            console.error(err);
            throw err;
        });
    }

    getItem(storeName, id) {
        return this.dbOperation(this.db[storeName].get(id));
    }

    addItem(storeName, item) {
        return this.dbOperation(this.db[storeName].add(item));
    }

    getAllItems(storeName) {
        return this.dbOperation(this.db[storeName].toArray());
    }

    updateItem(storeName, item) {
        return this.dbOperation(this.db[storeName].put(item));
    }

    deleteItem(storeName, id) {
        return this.dbOperation(this.db[storeName].delete(id));
    }

    getSettings() {
        return this.getAllItems('settings');
    }

    updateSetting(name, value) {
        return this.dbOperation(
            this.db.settings
                .where('name')
                .equals(name)
                .modify({ value })
        );
    }

    getConversationMessages(conversationId) {
        // Fetch all entries for this conversation, sorted by timestamp
        return this.db.conversationEntries
            .where("conversationId")
            .equals(conversationId)
            .sortBy("timestamp")
            .then(entries => {
                // For each entry, fetch the corresponding message
                let promises = entries.map(entry => {
                    // Based on the type of the message, choose the table to fetch from
                    let table;
                    switch (entry.messageType) {
                        case "text":
                            table = this.db.textMessages;
                            break;
                        case "audio":
                            table = this.db.audioMessages;
                            break;
                        case "image":
                            table = this.db.imageMessages;
                            break;
                        case "file":
                            table = this.db.fileMessages;
                            break;
                        case "location":
                            table = this.db.locationMessages;
                            break;
                        default:
                            break;
                    }

                    // Fetch the message from the chosen table
                    table.get(entry.messageId).then(result => {
                        console.log(result);
                    }).catch(error => {
                        console.error('Error getting item:', error);
                    });

                    return table.get(entry.messageId);
                });

                // Wait for all message fetches to complete
                var dd = Promise.all(promises);
                return Promise.all(promises);
            })
            .then(messages => JSON.stringify(messages));
    }



}

// Instantiate the service
const dexieService = new DexieService('ShareSafe');

// Initialize the database
dexieService.initialize();

// Expose the service to the global window object
window.dexieService = {
    getItem: (storeName, id) => dexieService.getItem(storeName, id),
    addItem: (storeName, item) => dexieService.addItem(storeName, item),
    getAllItems: (storeName) => dexieService.getAllItems(storeName),
    updateItem: (storeName, item) => dexieService.updateItem(storeName, item),
    deleteItem: (storeName, id) => dexieService.deleteItem(storeName, id),
    getSettings: () => dexieService.getSettings(),
    updateSetting: (name, value) => dexieService.updateSetting(name, value),
    getAllConversationMessages: (conversationID) => dexieService.getConversationMessages(conversationID),

};
